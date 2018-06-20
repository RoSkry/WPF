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

namespace PreviousData
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Item> Items { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Items = new List<Item> 
            {
                new Item{Value=80.23},
                new Item { Value = 126.17 },
                new Item { Value = 130.21 },
                new Item { Value = 115.28 },
                new Item { Value = 131.21 },
                new Item { Value = 135.22 },
                new Item { Value = 120.27 },
                new Item { Value = 110.25 },
                new Item { Value = 90.20 }
            };

            //DataContext = this;
        }
    }
}