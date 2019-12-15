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
    /// Логика взаимодействия для AccessRegistration.xaml
    /// </summary>
    public partial class AccessRegistration : Window
    {
        private string login;
        private string email;
        private string hash_password;
        private int typeId;
        public AccessRegistration(string login, string email, string hash_password, int typeId)
        {
            InitializeComponent();
            this.login = login;
            this.email = email;
            this.hash_password = hash_password;
            this.typeId = typeId;
        }

        private void Reject_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Access_Click(object sender, RoutedEventArgs e)
        {
            AccessRegistrationView view = new AccessRegistrationView();
            view.Access(login, email, hash_password, typeId);
            Close();
        }
    }
}
