using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Presenter
{
    public class TesterWindowPresenter:ITesterWindowPresenter
    {
        private AutomaticFeed automaticFeed;
        public TesterWindowPresenter()
        {
            automaticFeed = new AutomaticFeed();
        }

        public void StartEmulation ()
        {
            automaticFeed.StartEmulation();
        }

        public void FinishEmulation ()
        {
            automaticFeed.FinishEmulation();
        }

        public void EstablishSpeed (int speed)
        {
            Client client = new Client();
            client.EstablishTime(speed);
        }

        public int AskTime()
        {
            Client client = new Client();
            return client.AskTime();
        }

        public DataTable TakeData()
        {
            DataBaseForTester dataForTester = new DataBaseForTester();
            return dataForTester.TakeData();
        }

    }

    
}
