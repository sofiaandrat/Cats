using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Presenter
{
    public class AddFeederPresenter:IAddFeederPresenter
    {
        public AddFeederPresenter()
        {

        }

        public bool CheckPassword(int UserId, string password)
        {
            DataBaseUser db = new DataBaseUser();
            string login = db.TakeALogin(UserId);
            return db.Login(password, login)[1] != 0;
        }

        public void AddFeeder(int UserId, int amount, string tag)
        {
            DataBaseFeeder dataBaseFeeder = new DataBaseFeeder();
            dataBaseFeeder.AddFeeder(UserId, amount, tag);
        }
    }
}
