using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace hometask
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
           List<Product> products;
        public MainWindow()
        {
            InitializeComponent();
            products = new List<Product>()
            {
            new Product {Name="Potato",Code=10,Count=5,Price=12.5,RealPrice=17 },
           new Product { Name = "Bannana", Code = 20, Count = 2, Price = 30, RealPrice = 35 },
            new Product { Name = "Pork", Code = 120, Count = 1, Price = 56, RealPrice = 70 },
            new Product { Name = "Eggs", Code = 66, Count = 10, Price = 18, RealPrice = 19 },
           new Product { Name = "Water", Code = 76, Count = 1, Price = 11, RealPrice = 14 },

        };
            lstbox.ItemsSource = products;
            lstbox.SelectedIndex = 0;

        }

        private void nextbtn_Click(object sender, RoutedEventArgs e)
        {
            if(lstbox.Items.Count-1>lstbox.SelectedIndex)
            lstbox.SelectedIndex++;
        }

        private void previousbtn_Click(object sender, RoutedEventArgs e)
        {
            if(lstbox.SelectedIndex>0)
                lstbox.SelectedIndex--;
        }
        //если выбрано Buy
        private void chbx_Checked(object sender, RoutedEventArgs e)
        {
            if(chbx.IsChecked==true)
            {
                products[lstbox.SelectedIndex].Purchased = true;
                realprice.IsReadOnly = false;
            }
           
        }

        private void lstbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            realprice.IsReadOnly = true;
        }
        //если сбрасываем Buy
        private void chbx_Unchecked(object sender, RoutedEventArgs e)
        {
            realprice.IsReadOnly = true;
        }
    }
}
