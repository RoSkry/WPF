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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace exam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random rand;
        TimeSpan d1;
        TimeSpan d2;
        TimeSpan d3;
        TimeSpan d4;
        TimeSpan d5;
        Storyboard myStoryboard;
        DoubleAnimation myDoubleAnimation;
        public MainWindow()
        {
            InitializeComponent();
            rand = new Random();
            myStoryboard = new Storyboard();
            myDoubleAnimation = new DoubleAnimation();
            myStoryboard.Completed += new EventHandler(MyStoryboard_Completed);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            label1.Margin = new Thickness(162, -167, 2, 2);
            label2.Margin = new Thickness(162, -107, 2, 2);
            label3.Margin = new Thickness(162, -47, 2, 2);
            label4.Margin = new Thickness(162, -107, 2, 2);
            label5.Margin = new Thickness(162, -47, 2, 2);
            rect1.Fill = (Brush)new BrushConverter().ConvertFromString("#FF16EC16");
            rect2.Fill = (Brush)new BrushConverter().ConvertFromString("#FF16EC16");
            rect3.Fill = (Brush)new BrushConverter().ConvertFromString("#FF16EC16");
            rect4.Fill = (Brush)new BrushConverter().ConvertFromString("#FF16EC16");
            rect5.Fill = (Brush)new BrushConverter().ConvertFromString("#FF16EC16");

            // rec33.Visibility = Visibility.Visible;
            myDoubleAnimation.From = 0;
            myDoubleAnimation.To = 500;

            d1 = TimeSpan.FromSeconds(rand.Next(2, 17));
            myDoubleAnimation.Duration = new Duration(d1);
            myStoryboard.Children.Add(myDoubleAnimation);
            Storyboard.SetTargetName(myDoubleAnimation,"rect1");
            Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath(Rectangle.WidthProperty));
            myStoryboard.Begin(this);
           
            d2 = TimeSpan.FromSeconds(rand.Next(2, 17));
            myDoubleAnimation.Duration = new Duration(d2);
            Storyboard.SetTargetName(myDoubleAnimation, "rect2");    
            myStoryboard.Begin(this);

            d3 = TimeSpan.FromSeconds(rand.Next(2, 17));
            myDoubleAnimation.Duration = new Duration(d3);   
            Storyboard.SetTargetName(myDoubleAnimation, "rect3");
            myStoryboard.Begin(this);

            d4 = TimeSpan.FromSeconds(rand.Next(2, 17));
            myDoubleAnimation.Duration = new Duration(d4);
            Storyboard.SetTargetName(myDoubleAnimation, "rect4");
            myStoryboard.Begin(this);

            d5 = TimeSpan.FromSeconds(rand.Next(2, 17));
            myDoubleAnimation.Duration = new Duration(d5);
            Storyboard.SetTargetName(myDoubleAnimation, "rect5");
        
            myStoryboard.Begin(this);

            

        }

        private void MyStoryboard_Completed(object sender, EventArgs e)
        {
            if (d1 < d2 && d1 < d3 && d1 < d4 && d1 < d5)
            {
                label1.Margin = new Thickness(322, -167, 2, 2);
                rect1.Fill = new SolidColorBrush(Colors.Red);
                rect2.Fill = new SolidColorBrush(Colors.Yellow);
                rect3.Fill = new SolidColorBrush(Colors.Yellow);
                rect4.Fill = new SolidColorBrush(Colors.Yellow);
                rect5.Fill = new SolidColorBrush(Colors.Yellow);
            }
            else if (d2 < d1 && d2 < d3 && d2 < d4 && d2 < d5)
            {
                label2.Margin = new Thickness(322 ,- 107, 2, 2);
                rect2.Fill = new SolidColorBrush(Colors.Red);
                rect1.Fill = new SolidColorBrush(Colors.Yellow);
                rect3.Fill = new SolidColorBrush(Colors.Yellow);
                rect4.Fill = new SolidColorBrush(Colors.Yellow);
                rect5.Fill = new SolidColorBrush(Colors.Yellow);

            }
            else if (d3 < d1 && d3 < d2 && d3 < d4 && d3 < d5)
            {
                label3.Margin = new Thickness(322, - 47, 2, 2);
                rect3.Fill = new SolidColorBrush(Colors.Red);
                rect2.Fill = new SolidColorBrush(Colors.Yellow);
                rect1.Fill = new SolidColorBrush(Colors.Yellow);
                rect4.Fill = new SolidColorBrush(Colors.Yellow);
                rect5.Fill = new SolidColorBrush(Colors.Yellow);
            }
            else if (d4 < d2 && d4 < d3 && d4 < d1 && d4 < d5)
            {
                label4.Margin = new Thickness(322, -107, 2, 2);
                rect4.Fill = new SolidColorBrush(Colors.Red);
                rect2.Fill = new SolidColorBrush(Colors.Yellow);
                rect3.Fill = new SolidColorBrush(Colors.Yellow);
                rect1.Fill = new SolidColorBrush(Colors.Yellow);
                rect5.Fill = new SolidColorBrush(Colors.Yellow);
            }
            else if (d5 < d2 && d5 < d3 && d5 < d4 && d5 < d1)
            {
                label5.Margin = new Thickness(322, -47, 2 ,2);
                rect5.Fill = new SolidColorBrush(Colors.Red);
                rect2.Fill = new SolidColorBrush(Colors.Yellow);
                rect3.Fill = new SolidColorBrush(Colors.Yellow);
                rect4.Fill = new SolidColorBrush(Colors.Yellow);
                rect1.Fill = new SolidColorBrush(Colors.Yellow);
            }
           

        }


       
    }
}
