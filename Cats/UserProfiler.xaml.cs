using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
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
        }

        private void AddFeeder_Click(object sender, RoutedEventArgs e)
        {
            UserProfilerView view = new UserProfilerView();
            view.AddFeeder(UserId);
            feeders = view.updateFeederList(UserId);
            Feeders.Dispatcher.BeginInvoke(new Action(delegate ()
            {
                Feeders.ItemsSource = feeders.DefaultView;
            }));
        }

        private void Feeders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
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
        }

        private void AddTag_Click(object sender, RoutedEventArgs e)
        {
            if (Tags.Items.Count != 0)
            {
                UserProfilerView userProfilerView = new UserProfilerView();
                userProfilerView.AddTag(currentFeederId);
            }
        }
    }
}
