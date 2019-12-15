using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presenter;

namespace View
{
    public class AccessRegistrationView
    {
        public AccessRegistrationView()
        {
            
        }
        public void Access(string login, string email, string hash_password, int typeId)
        {
            AccessRegistrationPresenter presenter = new AccessRegistrationPresenter();
            presenter.AccessRegistration(login, email, hash_password, typeId);
        }
    }
}
