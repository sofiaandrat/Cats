﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenter
{
    interface IAddSchedulePresenter
    {
        void AddSchedule(int amount, int timer, string name, int feederId);
    }
}