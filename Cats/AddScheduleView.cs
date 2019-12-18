using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presenter;

namespace View
{
    public class AddScheduleView
    {
        public AddScheduleView() { }
        public void AddSchedule(int amount, int timer, string name, int feederId)
        {
            AddSchedulePresenter addSchedulePresenter = new AddSchedulePresenter();
            addSchedulePresenter.AddSchedule(amount, timer, name, feederId);
        }
    }
}
