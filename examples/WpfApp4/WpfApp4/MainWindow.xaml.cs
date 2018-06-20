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

namespace WpfApp4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TaskWindow taskWindow = new TaskWindow();
            taskWindow.ViewModel = "ViewModel";

            taskWindow.Owner = this;
          
            taskWindow.Show();


            foreach (Window window in App.Current.Windows)
            {
                window.Background = new SolidColorBrush(Colors.Red);

                // если окно - объект TaskWindow
                if (window is TaskWindow)
                    window.Title = "Новый заголовок!";
            }

            //foreach (Window window in this.OwnedWindows)
            //{
            //    window.Background = new SolidColorBrush(Colors.Red);

            //    if (window is TaskWindow)
            //        window.Title = "Новый заголовок!";
            //}

        }
    }
}
