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
using System.Threading;

namespace Cats
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        private Exception Ex;
        public Registration()
        {
            InitializeComponent();
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            Login_in_use.Visibility = Visibility.Hidden;
            try
            {
                if(email.Text.Length < 5 || !email.Text.Contains("@") || !email.Text.Contains("."))
                    throw Ex;
                if (Password.Password.Length == 0)
                    throw Ex;
                if (Login.Text.Length == 0)
                    throw Ex;
                RegistrationView Registration = new RegistrationView(email.Text, Password.Password, Login.Text);
                if (!Registration.CheckPresenter())
                    Registration.Presenter();
                else
                    throw Ex;
                    
            }
            catch
            {
                Login_in_use.Visibility = Visibility.Visible;
            }
        }
    }
}
