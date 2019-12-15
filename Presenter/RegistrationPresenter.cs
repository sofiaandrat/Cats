using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace Presenter
{
    public class RegistrationPresenter:IRegistrationPresenter
    {
        private string email;
        private string password;
        private string login;
        public RegistrationPresenter(string email, string password, string login)
        {
            this.email = email;
            this.password = password;
            this.login = login;
        }
        public void Register()
        {
            DataBaseUser reg = new DataBaseUser();
            reg.Insert(login, email, password);
        }
        public bool Check()
        {
            DataBaseUser checking = new DataBaseUser();
            return checking.IsItFree(login, email);
        }
    }
}
