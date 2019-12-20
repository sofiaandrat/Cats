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
    /// Логика взаимодействия для TesterWindow.xaml
    /// </summary>
    public partial class TesterWindow : Window
    {
        Thread ButtonHandler;
        TesterWidowView testerWindowView;
        Mutex mutex;
        public TesterWindow()
        {
            InitializeComponent();
            testerWindowView = new TesterWidowView();
            mutex = new Mutex();
            ButtonHandler = new Thread(Button);
            ButtonHandler.Start();
        }

        private void Switch_Click(object sender, RoutedEventArgs e)
        {
            mutex.WaitOne();
            if(Switch.Content.ToString() == "OFF")
            {
                Switch.Content = "ON";
                Switch.Background = Brushes.LightGreen;
            } else
            {
                Switch.Content = "OFF";
                Switch.Background = Brushes.LightPink;
            }
            mutex.ReleaseMutex();
        }

        private void Button()
        {
            while(true)
            {
                Speed.Dispatcher.BeginInvoke(new Action(delegate ()
                {
                   testerWindowView.EstablishSpeed((int)Speed.Value);
                }));
                Switch.Dispatcher.BeginInvoke(new Action(delegate ()
                {
                    if (Switch.Content.ToString() == "OFF")
                        testerWindowView.StartEmulation();
                    else
                        testerWindowView.FinishEmulation();
                }));
                Timer.Dispatcher.BeginInvoke(new Action (delegate ()
                {
                    int t = testerWindowView.AskTime();
                    Timer.Content = (t / 60).ToString() + ":" + (t - (t / 60) * 60).ToString();
                }));
                SpeedLabel.Dispatcher.BeginInvoke(new Action (delegate()
                {
                    SpeedLabel.Content = (int)Speed.Value;
                }));
                DataTable dataTable = new DataTable();
                dataTable = testerWindowView.TakeData();
                Data.Dispatcher.BeginInvoke(new Action(delegate ()
                {
                   Data.ItemsSource = dataTable.DefaultView;
                }));
                Thread.Sleep(2000);
            }
        }


    }
}
