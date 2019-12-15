using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    interface IDataBaseUser
    {
        void Insert(string name, string email, string password, int typeId = 1);
        string hash(string password);
        bool IsItFree(string name, string email);
        int Login(string login, string password);
    }
}
