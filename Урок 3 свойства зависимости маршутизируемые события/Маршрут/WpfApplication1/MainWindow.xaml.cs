using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication1
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

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            textBox1.Text += "MouseDown_StackPanel\n";
        }

        private void button1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            textBox1.Text += "MouseDown_Button1\n";
        }

        private void button2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            textBox1.Text += "MouseDown_Button2\n";
            e.Handled = true;
        }

        private void button3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            textBox1.Text += "MouseDown_Button3\n";
            e.Handled = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //последний параметр в true - получение события StackPanel_MouseDown, даже если для события button2_MouseDown был установлен флаг Handled: Handled=true
            button2.AddHandler(UIElement.MouseDownEvent, new MouseButtonEventHandler(StackPanel_MouseDown), true);
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            textBox1.Clear();
        }

        private void button4_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            textBox1.Text += "PreviewMouseDown_Button4\n";
            e.Handled = true;
        }

        private void button1_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            textBox1.Text += "PreviewMouseDown_Button1\n";
        }

        private void StackPanel_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            textBox1.Text += "PreviewMouseDown_StackPanel\n";
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            //textBox1.Text += "Click_Button2\n";
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            RadioButton selectedRadio = (RadioButton)e.Source;
            textBox1.Text = "Вы выбрали: " + selectedRadio.Content.ToString();
        }
    }
}
