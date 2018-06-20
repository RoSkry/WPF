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
using System.Windows.Threading;

namespace animation1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {

        long start;
        double duration = 5000;
        double from = 9.0;
        double to = 18.0;

        public MainWindow()
        {
            InitializeComponent();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(50);
            start = Environment.TickCount;
            timer.Tick += timer_Tick;
            timer.IsEnabled = true;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            long elapsed = Environment.TickCount - start;
            if (elapsed >= duration)
            {
                button1.FontSize = to;
                ((DispatcherTimer)sender).IsEnabled = false;
                return;
            }
            double increase = to - from;
            button1.FontSize = from + (increase / (duration / elapsed));
        }
    }
}
