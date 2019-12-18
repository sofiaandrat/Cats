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
using System.Windows.Navigation;
using System.Windows.Shapes;
using View;

namespace Cats
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainWindowView loginView = new MainWindowView();
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            Registration form = new Registration();
            form.Show();
        }
        private void Log_in_Click(object sender, RoutedEventArgs e)
        {
            LoginView mainWindow = new LoginView(Login.Text, PasswordBox.Password);
            List <int> data = mainWindow.Presenter();
            if (data[0] == 0)
                Wrong_entrance.Visibility = Visibility.Visible;
            if (data[0] == 2)
            {
                Admin form = new Admin();
                form.Show();
            }
            if (data[0] == 1)
            {
                UserProfiler form = new UserProfiler(data[1]);
                form.Show();
            }
        }
    }
}
