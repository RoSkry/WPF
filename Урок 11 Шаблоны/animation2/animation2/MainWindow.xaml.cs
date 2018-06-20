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

namespace animation2
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


        bool isSpinning = false;

        private void button1_MouseEnter(object sender, MouseEventArgs e)
        {
            if (!isSpinning)
            {
                isSpinning = true;
                // Создать объект анимации double и зарегистрировать с событием Completed. 
                DoubleAnimation dblAnim = new DoubleAnimation();
                dblAnim.Completed += animation_Completed;

                //На завершение поворота кнопке отводится 4 секунды. 
                dblAnim.Duration = new Duration(TimeSpan.FromSeconds(4));

                // Установить начальное и конечное значения. 
                dblAnim.From = 0;
                dblAnim.To = 360;

                // Бесконечный цикл.
                //dblAnim.RepeatBehavior = RepeatBehavior.Forever;
                // Повторить три раза. 
                //dblAnim.RepeatBehavior = new RepeatBehavior(3);
                // Повторять в течение 10 секунд. 
                dblAnim.RepeatBehavior = new RepeatBehavior(TimeSpan.FromSeconds(10));

                // Создать объект RotateTransform и присвоить 
                // его свойству RenderTransform кнопки. 
                RotateTransform rt = new RotateTransform();

                // вращать вокруг центра
                button1.RenderTransformOrigin = new Point(0.5, 0.5);
                button1.RenderTransform = rt;
                // Выполнить анимацию объекта RotateTransform. 
                // Бесконечный цикл. 

                rt.BeginAnimation(RotateTransform.AngleProperty, dblAnim);
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation dblAnim = new DoubleAnimation();
            dblAnim.From = 1.0;
            dblAnim.To = 0.0;
            dblAnim.AutoReverse = true; // по завершении - запуск в обратном порядке
            button1.BeginAnimation(Button.OpacityProperty, dblAnim);

            //ColorAnimation dblAnim = new ColorAnimation();
            //dblAnim.From = Colors.Red ;
            //dblAnim.To = Colors.Green;
            //dblAnim.Duration= new Duration(TimeSpan.FromMilliseconds(7000));
            //dblAnim.AutoReverse = true; // по завершении - запуск в обратном порядке
            //button1.BeginAnimation(Button.BackgroundProperty, dblAnim);
        }



        private void animation_Completed(object sender, EventArgs e)
        {
            isSpinning = false;
        }
    }
}
