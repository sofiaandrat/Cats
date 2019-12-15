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
    /// Логика взаимодействия для UserProfiler.xaml
    /// </summary>
    public partial class UserProfiler : Window
    {
        private int UserId;
        public UserProfiler(int UserId)
        {
            InitializeComponent();
            this.UserId = UserId;
        }

        private void AddFeeder_Click(object sender, RoutedEventArgs e)
        {
            UserProfilerView view = new UserProfilerView();
            view.AddFeeder(this.UserId);
        }
    }
}
