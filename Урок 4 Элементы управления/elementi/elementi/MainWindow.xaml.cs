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

namespace elementi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Label myLabel = new Label
            //{
            //    Content = "Hello",
            //    Foreground = new SolidColorBrush(Colors.Red),
            //    Margin = new Thickness { Left = 56 }
            //};
            //grid.Children.Add(myLabel);

            //Button butt = new Button { Content = "Кнопка" };
            //butt.Click += new RoutedEventHandler( Butt_Click);
            //grid.Children.Add(butt);
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
           

        }
    }
}
