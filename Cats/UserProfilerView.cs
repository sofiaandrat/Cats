﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Presenter;

namespace View
{
    public class UserProfilerView
    {
        public UserProfilerView() { }
        public void AddFeeder(int UserId)
        {
            AddFeeder form = new AddFeeder(UserId);
            form.Show();
        }

        public DataTable updateFeederList(int userId)
        {
            UserProfilerPresenter userProfilerPresenter = new UserProfilerPresenter();
            return userProfilerPresenter.updateFeederList(userId);
        }

        public DataTable showTags(int feederId)
        {
            UserProfilerPresenter userProfilerPresenter = new UserProfilerPresenter();
            return userProfilerPresenter.showTags(feederId);
        }

        public void AddTag(int feederId)
        {
            AddTag form = new AddTag(feederId);
            form.Show();
        }

        public void deleteTag(int tagId)
        {
            DeleteTag form = new DeleteTag(tagId);
            form.Show();
        }

        public void AddSchedule(int feederId)
        {
            AddSchedule form = new AddSchedule(feederId);
            form.Show();
        }

        public void ManualFeed(int feederId)
        {
            ManualFeeding form = new ManualFeeding(feederId);
            form.Show();
        }

        public int AskTime()
        {
            UserProfilerPresenter userProfilerPresenter = new UserProfilerPresenter();
            return userProfilerPresenter.AskTime();
        }
    }
}
