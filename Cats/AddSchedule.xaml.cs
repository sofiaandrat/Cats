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
    /// Логика взаимодействия для AddSchedule.xaml
    /// </summary>
    public partial class AddSchedule : Window
    {
        private int feederId;
        private Exception Ex;
        public AddSchedule(int feederId)
        {
            InitializeComponent();
            this.feederId = feederId;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            WrongInput.Visibility = Visibility.Hidden;
            try
            {
                AddScheduleView addScheduleView = new AddScheduleView();
                addScheduleView.AddSchedule(Convert.ToInt32(amount.Text), Convert.ToInt32(Timer.Text), name.Text, feederId);
                if (Convert.ToInt32(amount.Text) < 0 || Convert.ToInt32(Timer.Text) < 0)
                    throw Ex;
                Close();
            }
            catch
            {
                WrongInput.Visibility = Visibility.Visible;
            }

        }
    }
}
