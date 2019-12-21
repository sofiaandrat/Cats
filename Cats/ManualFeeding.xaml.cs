using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для ManualFeeding.xaml
    /// </summary>
    public partial class ManualFeeding : Window
    {
        private int feederId;
        private Exception Ex;

        public ManualFeeding(int feederId)
        {
            InitializeComponent();
            this.feederId = feederId;
        }

        private void RejectTag_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AcceptTag_Click(object sender, RoutedEventArgs e)
        {
            WrongInput.Visibility = Visibility.Hidden;
            ManualFeedingView manualFeedingView = new ManualFeedingView();
            try
            {
                manualFeedingView.ManualFeed(feederId, Convert.ToInt32(Amount.Text));
                if (Convert.ToInt32(Amount.Text) < 0)
                    throw Ex;
            }
            catch
            {
                WrongInput.Visibility = Visibility.Visible;
            }
        }
    }
}
