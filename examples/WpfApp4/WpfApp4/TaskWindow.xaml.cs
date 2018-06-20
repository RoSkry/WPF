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

namespace WpfApp4
{
    /// <summary>
    /// Interaction logic for TaskWindow.xaml
    /// </summary>
    public partial class TaskWindow : Window
    {
        public string ViewModel { get; set; }

        public TaskWindow()
        {
            InitializeComponent();
        }
        public void ChageOwnerBackground()
        {
            this.Owner.Background = new SolidColorBrush(Colors.Red);
        }

        public void ShowViewModel()
        {
            MessageBox.Show(ViewModel);
        }
    }
}
