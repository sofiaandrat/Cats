using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presenter;

namespace View
{
    public class AddFeederView
    {
        public AddFeederView()
        {

        }
        public bool Add(int UserId, string password, int amount = 1000, string tag = "")
        {
            AddFeederPresenter addFeederPresenter = new AddFeederPresenter();
            if (addFeederPresenter.CheckPassword(UserId, password))
                addFeederPresenter.AddFeeder(UserId, amount, tag);
            else
                return false;
            return true;
        }
    }
}
