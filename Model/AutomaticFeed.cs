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
            mutex = new Mutex();
            thread = new Thread(FeedEverybody);
            thread.Start();
        }

        public void StartEmulation()
        {
            try
            {
                thread.Resume();
            }
            catch(Exception ex)
            {
                return;
            }
        }

        public void FinishEmulation()
        {
            try
            {
                thread.Suspend();
            }
            catch(Exception ex)
            {
                return;
            }
        }

        private void FeedEverybody()
        {
            
            while(true)
            {
                mutex.WaitOne();
                Client client = new Client();
                currentTime = client.AskTime();
                Thread.Sleep(1000);
                OneIteration = client.AskTime() - currentTime;
                DataBaseSchedule dataBaseSchedule = new DataBaseSchedule();
                currentTime = client.AskTime();
                events = dataBaseSchedule.GetEvents();
                for(int i = 0; i < events.Count(); i++)
                {
                    if(events[i].Time > currentTime - 6 * OneIteration && events[i].Time <= currentTime)
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
