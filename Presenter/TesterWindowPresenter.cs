using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Presenter
{
    public class TesterWindowPresenter:ITesterWindowPresenter
    {
        private static AutomaticFeed automaticFeed;
        public TesterWindowPresenter()
        {
            automaticFeed = new AutomaticFeed();
        }

        public void StartEmulation()
        {
            automaticFeed.StartEmulation();
        }

        public void FinishEmulation()
        {
            automaticFeed.FinishEmulation();
        }
    }

    
}
