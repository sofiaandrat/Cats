using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Presenter
{
    interface IAdminPresenter
    {
        DataTable RegistrationQueuePresenter();
        DataTable UserList();
        void AddThread(ref Thread thread);
    }
}
