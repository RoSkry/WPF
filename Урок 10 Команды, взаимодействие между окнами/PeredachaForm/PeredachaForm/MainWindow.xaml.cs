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

namespace PeredachaForm
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
        //Action void, Func возвращает
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1(mainText.Text);
            window1.RefreshTextBox += SetText;
            window1.ShowDialog();
        }

        private void SetText(string obj)
        {
            mainText.Text = obj;
        }
    }
}
