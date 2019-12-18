using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presenter;

namespace View
{
    public class ManualFeedingView
    {
        public ManualFeedingView() { }
        public void ManualFeed(int feederId, int amount)
        {
            ManualFeedingPresenter manualFeedingPresenter = new ManualFeedingPresenter();
            manualFeedingPresenter.ManualFeed(feederId, amount);
        }
    }
}
