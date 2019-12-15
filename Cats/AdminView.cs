using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presenter;

namespace View
{
    public class AdminView
    {
        public AdminView() { }
        public DataTable Registration_queue()
        {
            AdminPresenter queue = new AdminPresenter();
            return queue.RegistrationQueuePresenter();
        }
    }
}
