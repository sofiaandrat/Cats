using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Presenter
{
    public class AccessRegistrationPresenter:IAccessRegistrationPresenter
    {
        public AccessRegistrationPresenter()
        {

        }
        public void AccessRegistration(string login, string email, string hash_password, int typeId)
        {
            DataBaseUser dataBaseUser = new DataBaseUser();
            dataBaseUser.Insert(new User(login, email, hash_password, typeId));
            dataBaseUser.Delete(login);
        }
    }
}
