using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenter
{
    interface IManualFeedingPresenter
    {
        void ManualFeed(int feederId, int count);
    }
}
