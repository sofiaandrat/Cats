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
    /// Логика взаимодействия для AddFeeder.xaml
    /// </summary>
    public partial class AddFeeder : Window
    {
        private int UserId;
        public AddFeeder(int UserId)
        {
            InitializeComponent();
            this.UserId = UserId;
        }
        private void AddBowl_Click_1(object sender, RoutedEventArgs e)
        {
            WrongPassword.Visibility = Visibility.Hidden;
            AddFeederView view = new AddFeederView();
            if (!view.Add(UserId, Password.Password, Convert.ToInt32(amount.Text), Tag.Text))
                WrongPassword.Visibility = Visibility.Visible;
            else
                Close();
        }
    }
}
