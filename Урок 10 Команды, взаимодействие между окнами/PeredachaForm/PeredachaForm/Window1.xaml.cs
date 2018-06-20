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

namespace PeredachaForm
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Action<string> RefreshTextBox { get; set; }
        string _text;
        public Window1( string text)
        {
            InitializeComponent();
            _text = text;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RefreshTextBox(childText.Text);

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            childText.Text = _text;
        }
    }
}
