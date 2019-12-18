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
    /// Логика взаимодействия для DeleteTag.xaml
    /// </summary>
    public partial class DeleteTag : Window
    {
        private int tagId;
        public DeleteTag(int tagId)
        {
            Mutex mutex = new Mutex();
            mutex.WaitOne();
            InitializeComponent();
            this.tagId = tagId;
            mutex.ReleaseMutex();
        }

        private void YES_Click(object sender, RoutedEventArgs e)
        {
            DeleteTagView deleteTagView = new DeleteTagView();
            deleteTagView.deleteTag(tagId);
            Close();
        }

        private void NO_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
