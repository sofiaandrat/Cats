using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Model
{
    public class AdminModel
    {
        private DataTable data;
        public AdminModel()
        {
            RegistrationData data = new RegistrationData();
            this.data = data.Apdate_queue();
        }
        public DataTable Queue()
        {
            return this.data;
        }
    }
}
