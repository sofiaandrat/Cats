using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Model
{
    public class AutomaticFeed
    {
        Thread thread;
        private int currentTime;
        List<Event> events;
        private int OneIteration;
        Mutex mutex;
        public AutomaticFeed()
        {
            thread = new Thread(FeedEverybody);
            mutex = new Mutex();
            thread.Start();
        }

        private void FeedEverybody()
        {
            
            while(true)
            {
                mutex.WaitOne();
                Client client = new Client();
                currentTime = client.AskTime();
                Thread.Sleep(1000);
                OneIteration = currentTime - client.AskTime();
                DataBaseSchedule dataBaseSchedule = new DataBaseSchedule();
                currentTime = client.AskTime();
                events = dataBaseSchedule.GetEvents();
                for(int i = 0; i < events.Count(); i++)
                {
                    if(events[i].Time > currentTime - 5 * OneIteration && events[i].Time < currentTime)
                    {
                        DataBaseFeeder dataBaseFeeder = new DataBaseFeeder();
                        dataBaseFeeder.ManualFeeding(events[i].FeederId, events[i].Amount);
                    }
                }
                mutex.ReleaseMutex();
                Thread.Sleep(5000);
            }

        }
    }
}
