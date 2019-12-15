using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenter
{
    interface IAddFeederPresenter
    {
        bool CheckPassword(int UserId, string password);
        void AddFeeder(int UserId, int amount, string tag);
    }
}
