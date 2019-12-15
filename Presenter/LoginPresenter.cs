using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenter
{
    public class LoginPresenter:ILoginPresenter
    {
        private string login;
        private string password;
        public LoginPresenter(string login, string password)
        {
            this.login = login;
            this.password = password;
        }
        public int Login()
        {
            DataBaseUser login = new DataBaseUser();
            return login.Login(this.login, this.password);
        }

    }
}
