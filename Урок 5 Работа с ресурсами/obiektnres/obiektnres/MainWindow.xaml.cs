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

namespace obiektnres
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
            //SolidColorBrush solidColorBrush = this.Resources["buttonBrush"] as SolidColorBrush;
            //solidColorBrush.Opacity = 0.5;
            //this.Resources["ButtonBrush"] = new SolidColorBrush(Colors.Red);

            //this.Resources["ButtonBrush"] = new SolidColorBrush(Color.FromRgb(23,72,37));
            //SolidColorBrush solidColorBrush = this.Resources["ButtonBrush"] as SolidColorBrush;


            Application.Current.Resources["ButtonBrush"] = Brushes.Red;



        }
    }
}
