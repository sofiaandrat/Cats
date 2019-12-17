using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    interface IDataBaseUser
    {
        void Insert(User user);
        void Insert(string name, string email, string password, int typeId);
        bool IsItFree(string name, string email);
        List <int> Login(string login, string password);
        void Delete(string login);
        string TakeALogin(int userId);
        DataTable UsersList();
    }
}
