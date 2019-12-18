using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Presenter
{
    public class AddSchedulePresenter:IAddSchedulePresenter
    {
        public AddSchedulePresenter() { }
        public void AddSchedule(int amount, int timer, string name, int feederId)
        {
            DataBaseSchedule dataBaseSchedule = new DataBaseSchedule();
            dataBaseSchedule.AddSchedule(amount, timer, name, feederId);
        }
    }
}
