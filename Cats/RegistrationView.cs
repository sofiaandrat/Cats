using Presenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cats
{
    class RegistrationView
    {
        private string email;
        private string password;
        private string login;
        public RegistrationView(string email, string password, string login)
        {
            this.email = email;
            this.password = password;
            this.login = login;
        }
        public void Presenter()
        {
            RegistrationPresenter reg = new RegistrationPresenter(email, password, login);
            reg.Register();
        }
        public bool CheckPresenter()
        {
            RegistrationPresenter reg = new RegistrationPresenter(email, password, login);
           return reg.Check();
        }
    }
}
