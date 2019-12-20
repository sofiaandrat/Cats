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
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        private DataTable dt;
        private DataTable users;
        private Thread queue;
        private static Mutex mutexObj;
        public Admin()
        {
            InitializeComponent();
            DataTable dt = new DataTable();
            DataTable users = new DataTable();
            mutexObj = new Mutex();
            queue = new Thread(new ThreadStart(Queue));
            AdminView adminView = new AdminView();
            queue.Start();
        }

        public void Queue()
        {
            while(true)
            {
                AdminView adminView = new AdminView();
                dt = adminView.Registration_queue();
                users = adminView.Users_list();
                Registration.Dispatcher.BeginInvoke(new Action(delegate ()
                {
                    Registration.ItemsSource = dt.DefaultView;
                }));
                Users.Dispatcher.BeginInvoke(new Action(delegate ()
                {
                    Users.ItemsSource = users.DefaultView;
                }));
                Thread.Sleep(2000);
            }
        }

        private void Registration_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mutexObj.WaitOne();
            AdminView adminView = new AdminView();
            DataGrid gd = (DataGrid)sender;
            DataRowView row_selected = gd.SelectedItem as DataRowView;
            if(row_selected != null)
            {
                string login = row_selected["name"].ToString();
                string email = row_selected["email"].ToString();
                string hash_password = row_selected["hash_password"].ToString();
                int typeId = Convert.ToInt32(row_selected["typeId"].ToString());
                adminView.AccessRegistration(login, email, hash_password, typeId);
            }
            mutexObj.ReleaseMutex();
        }
    }
}
