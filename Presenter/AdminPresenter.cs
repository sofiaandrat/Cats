using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Model;

namespace Presenter
{
    public class AdminPresenter:IAdminPresenter
    {
        public AdminPresenter() { }
        public DataTable RegistrationQueuePresenter()
        {
            AdminModel adminModel = new AdminModel();
            return adminModel.Queue();
        }

        public DataTable UserList()
        {
            AdminModel adminModel = new AdminModel();
            return adminModel.UserList();
        }
    }
}
