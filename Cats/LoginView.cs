using Presenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View
{
    class LoginView
    {
        private string login;
        private string password;
        public LoginView(string password, string login)
        {
            this.password = password;
            this.login = login;
        }
        public int Presenter()
        {
            LoginPresenter login = new LoginPresenter(this.login, this.password);
            return login.Login();            
        }
    }
}
