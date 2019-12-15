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
        DataTable dt;
        public Admin()
        {
            InitializeComponent();
            DataTable dt = new DataTable();
            Thread queue = new Thread(new ThreadStart(Queue));
            queue.Start();
            //AdminView adminView = new AdminView();
            //dt = adminView.Registration_queue();
            //Registration.ItemsSource = dt.DefaultView;
        }
        public void Queue()
        {
            while(true)
            {
                AdminView adminView = new AdminView();
                dt = adminView.Registration_queue();
                Registration.Dispatcher.BeginInvoke(new Action(delegate ()
                {
                    Registration.ItemsSource = dt.DefaultView;
                }));
                Thread.Sleep(10000);
            }
        }
    }
}
