﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Presenter;

namespace View
{
    public class AdminView
    {
        public AdminView() { }
        public DataTable Registration_queue()
        {
            AdminPresenter queue = new AdminPresenter();
            return queue.RegistrationQueuePresenter();
        }

        public DataTable Users_list()
        {
            AdminPresenter list = new AdminPresenter();
            return list.UserList();
        }

        public void AccessRegistration(string login, string email, string hash_password, int typeId)
        {
            AccessRegistration form = new AccessRegistration(login, email, hash_password, typeId);
            form.Show();
        }

        public void AddThread(ref Thread thread)
        {
            AdminPresenter adminPresenter = new AdminPresenter();
            adminPresenter.AddThread(ref thread);
        }
    }
}
