using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Event
    {
        private int scheduleId;
        public int ScheduleId
        {
            get { return scheduleId; }
            set { scheduleId = value; }
        }
        private int time;
        public int Time
        {
            get { return time; }
            set { time = value; }
        }
        private int amount;
        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        private int feederId;
        public int FeederId
        {
            get { return feederId; }
            set { feederId = value; }
        }
        public Event(int scheduleId, int time, int amount)
        {
            this.scheduleId = scheduleId;
            this.time = time;
            this.amount = amount;
        }

    }
}
