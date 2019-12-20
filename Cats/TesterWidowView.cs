using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presenter;

namespace View
{
    public class TesterWidowView
    {
        private TesterWindowPresenter testerWindowPresenter;
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

        public void EstablishSpeed(int speed)
        {
            testerWindowPresenter.EstablishSpeed(speed);
        }

        public int AskTime()
        {
            return testerWindowPresenter.AskTime();
        }

        public DataTable TakeData()
        {
            return testerWindowPresenter.TakeData();
        }
    }
}
