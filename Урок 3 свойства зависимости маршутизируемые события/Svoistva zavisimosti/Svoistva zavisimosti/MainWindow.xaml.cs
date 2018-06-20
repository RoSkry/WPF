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

namespace Svoistva_zavisimosti
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //propdp
        //public int MyProperty
        //{
        //    get { return (int)GetValue(MyPropertyProperty); }
        //    set { SetValue(MyPropertyProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty MyPropertyProperty =
        //    DependencyProperty.Register("MyProperty", typeof(int), typeof(ownerclass), new PropertyMetadata(0));


        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            FontSize = 12;
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            FontSize = 16;
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            button3.FontSize = 18;
        }

        private void StackPanel_Click(object sender, RoutedEventArgs e)
        {
            string name = ((Button)e.OriginalSource).Name;
            //object tag = ((Button)e.OriginalSource).Tag;
            switch (name)
            {
                case "button1":
                    this.FontSize = 12;
                    break;
                case "button2":
                    FontSize = 16;
                    break;
                case "button3":
                    button3.FontSize = 18;
                    break;
            }
        }
    }
}
