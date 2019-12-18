using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Presenter
{
    public class ManualFeedingPresenter:IManualFeedingPresenter
    {
        public ManualFeedingPresenter() { }
        public void ManualFeed(int feederId, int count)
        {
            DataBaseFeeder dataBaseFeeder = new DataBaseFeeder();
            dataBaseFeeder.ManualFeeding(feederId, count);
        }
    }
}
