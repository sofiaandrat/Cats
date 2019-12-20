using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presenter;

namespace View
{
    public class TesterWidowView
    {
        private static TesterWindowPresenter testerWindowPresenter;
        public TesterWidowView()
        {
            testerWindowPresenter = new TesterWindowPresenter();
        }

        public void StartEmulation()
        {
            
            testerWindowPresenter.StartEmulation();
        }

        public void FinishEmulation()
        {
            testerWindowPresenter.FinishEmulation();
        }
    }
}
