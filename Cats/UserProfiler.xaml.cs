using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace View
{
    /// <summary>
    /// Логика взаимодействия для UserProfiler.xaml
    /// </summary>
    public partial class UserProfiler : Window
    {
        private int UserId;
        private DataTable feeders;
        private DataTable tags;
        private int currentFeederId;
        private Thread tagsThread;
        private Mutex mutex;
        public UserProfiler(int UserId)
        {
            InitializeComponent();
            this.UserId = UserId;
            UserProfilerView view = new UserProfilerView();
            feeders = view.updateFeederList(UserId);
            Feeders.Dispatcher.BeginInvoke(new Action(delegate ()
            {
                Feeders.ItemsSource = feeders.DefaultView;
            }));
            mutex = new Mutex();
            tagsThread = new Thread(new ThreadStart(thread));
            tagsThread.Start();
        }

        private void AddFeeder_Click(object sender, RoutedEventArgs e)
        {
            mutex.WaitOne();
            UserProfilerView view = new UserProfilerView();
            view.AddFeeder(UserId);
            feeders = view.updateFeederList(UserId);
            Feeders.Dispatcher.BeginInvoke(new Action(delegate ()
            {
                Feeders.ItemsSource = feeders.DefaultView;
            }));
            mutex.ReleaseMutex();
        }

        private void Feeders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mutex.WaitOne();
            UserProfilerView userView = new UserProfilerView();
            DataGrid gd = (DataGrid)sender;
            DataRowView row_selected = gd.SelectedItem as DataRowView;
            if (row_selected != null)
            {
                int feederId = Convert.ToInt32(row_selected["feederId"].ToString());
                tags = userView.showTags(feederId);
                currentFeederId = feederId;
            }
            Tags.Dispatcher.BeginInvoke(new Action(delegate ()
            {
                Tags.ItemsSource = tags.DefaultView;
            }));
            mutex.ReleaseMutex();
        }

        private void AddTag_Click(object sender, RoutedEventArgs e)
        {
            mutex.WaitOne();
            if (Tags.Items.Count != 0)
            {
                UserProfilerView userProfilerView = new UserProfilerView();
                userProfilerView.AddTag(currentFeederId);
            }
            mutex.ReleaseMutex();
        }

        private void Tags_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mutex.WaitOne();
            UserProfilerView userView = new UserProfilerView();
            DataGrid gd = (DataGrid)sender;
            DataRowView row_selected = gd.SelectedItem as DataRowView;
            if (row_selected != null)
            {
                int tagId = Convert.ToInt32(row_selected["tagId"].ToString());
                userView.deleteTag(tagId);
            }
            mutex.ReleaseMutex();
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            mutex.WaitOne();
            Close();
            mutex.ReleaseMutex();
        }

        public void thread()
        {
            while (true)
            {
                UserProfilerView userView = new UserProfilerView();
                tags = userView.showTags(currentFeederId);
                Tags.Dispatcher.BeginInvoke(new Action(delegate ()
                {
                    Tags.ItemsSource = tags.DefaultView;
                }));
                time.Dispatcher.BeginInvoke(new Action(delegate ()
                {
                    int t = userView.AskTime();
                    time.Content = (t / 60).ToString() + ":" + (t - (t / 60) * 60).ToString();
                }));
                Thread.Sleep(2000);
            }
        }

        private void AddSchedule_Click(object sender, RoutedEventArgs e)
        {
            UserProfilerView userProfilerView = new UserProfilerView();
            userProfilerView.AddSchedule(currentFeederId);
        }

        private void Manual_Click(object sender, RoutedEventArgs e)
        {
            UserProfilerView userProfilerView = new UserProfilerView();
            userProfilerView.ManualFeed(currentFeederId);
        }
    }
}