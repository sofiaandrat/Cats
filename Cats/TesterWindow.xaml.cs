using System;
using System.Collections.Generic;
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
        TesterWidowView testerWidowView;
        Mutex mutex;
        public TesterWindow()
        {
            InitializeComponent();
            testerWidowView = new TesterWidowView();
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
                Switch.Dispatcher.BeginInvoke(new Action(delegate ()
                {
                    if (Switch.Content.ToString() == "ON")
                        testerWidowView.StartEmulation();
                    else
                        testerWidowView.FinishEmulation();
                }));
                Thread.Sleep(2000);
            }
        }
    }
}
