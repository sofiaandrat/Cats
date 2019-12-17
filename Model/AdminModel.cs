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
        public AdminModel()
        {
            
        }
        public DataTable Queue()
        {
            RegistrationData data = new RegistrationData();
            return data.Apdate_queue();
        }

        public DataTable UserList()
        {
            DataBaseUser data = new DataBaseUser();
            return data.UsersList();
        }

        public void AddThread(ref Thread thread)
        {
            SynchronizationClass synchronizationClass = new SynchronizationClass();
            synchronizationClass.SetThread(ref thread);
        }
    }
}
