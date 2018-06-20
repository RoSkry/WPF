using System;
using System.Collections.Generic;
using System.IO;
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
       
        List<ImageSource> images1,images2,images3,images4,images5;//для хранения фотографий по оценкам
        int i = 0;
        DirectoryInfo directoryInfo;
        FileInfo fileInfo;
        BitmapImage bitmapImage;
        RadioButton rb;   
        bool flag=false;//для работы  слайдера после фильтра
        int number = 0;
        public MainWindow()
        {
            InitializeComponent();
            images1 = new List<ImageSource>();
            images2 = new List<ImageSource>();
            images3 = new List<ImageSource>();
            images4 = new List<ImageSource>();
            images5 = new List<ImageSource>();
             
            list.SelectedIndex = 0;
            directoryInfo = new DirectoryInfo(Environment.CurrentDirectory + "/Winter");
            fileInfo = new FileInfo(directoryInfo + $"/{i}.jpg");
            bitmapImage = new BitmapImage(new Uri(fileInfo.FullName));
            razr.Text = $"{bitmapImage.PixelWidth}x{bitmapImage.PixelHeight}";
            size.Text = $"{fileInfo.Length}";
            image.Source = bitmapImage;
            
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            slider.Maximum = 9;
            flag = false;
             i = list.SelectedIndex;
              switch(i)
            {
                case 0: directoryInfo = new DirectoryInfo(Environment.CurrentDirectory + "/Winter"); break;
                case 1: directoryInfo = new DirectoryInfo(Environment.CurrentDirectory + "/Summer"); break;
                case 2: directoryInfo = new DirectoryInfo(Environment.CurrentDirectory + "/Sunset"); break;
                case 3: directoryInfo = new DirectoryInfo(Environment.CurrentDirectory + "/Flowers"); break;
                case 4: directoryInfo = new DirectoryInfo(Environment.CurrentDirectory + "/Ocean"); break;
                case 5: directoryInfo = new DirectoryInfo(Environment.CurrentDirectory + "/Future"); break;
                case 6: directoryInfo = new DirectoryInfo(Environment.CurrentDirectory + "/Cars"); break;
                case 7: directoryInfo = new DirectoryInfo(Environment.CurrentDirectory + "/Football"); break;
            }
           
            fileInfo = new FileInfo(directoryInfo + $"/{(int)slider.Value}.jpg");
            
            bitmapImage = new BitmapImage(new Uri(fileInfo.FullName));
        
            image.Source = bitmapImage;
            if (rb != null) rb.IsChecked = false;

        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //если нет фильтра
            if (!flag)
            {
                fileInfo = new FileInfo(directoryInfo + $"/{(int)slider.Value}.jpg");
                bitmapImage = new BitmapImage(new Uri(fileInfo.FullName));

                razr.Text = $"{bitmapImage.PixelWidth}x{bitmapImage.PixelHeight}";
                size.Text = $"{fileInfo.Length}";
                image.Source = bitmapImage;
            }
          // появляется фильтр
            else Choosesource(number);
            //убирает метку радиобатона при переходе на следующую картинку
            if (rb != null) rb.IsChecked = false;
        }
        //метод для выбора картинок в фильтре
        public void Choosesource(int count)
        {
            switch(count)
            {
                case 1: image.Source = images1[(int)slider.Value];break;
                case 2: image.Source = images2[(int)slider.Value]; break;
                case 3: image.Source = images3[(int)slider.Value]; break;
                case 4: image.Source = images4[(int)slider.Value]; break;
                case 5: image.Source = images5[(int)slider.Value]; break;
            }
        }


        private void nextbtn_Click(object sender, RoutedEventArgs e)
        {
            slider.Value++;
           
        }

        private void prevbtn_Click(object sender, RoutedEventArgs e)
        {
            slider.Value--;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
             ComboBox  combo = sender as ComboBox;
            ComboBoxItem selectedItem = (ComboBoxItem)combo.SelectedItem;
           slider.Value = 0;
           
            switch(selectedItem.Content.ToString())
            {
                case "1":
                    if (images1.Count > 0)
                    {
                        flag = true;
                        slider.Maximum = images1.Count - 1;
                        image.Source = images1[(int)slider.Value];
                        number = 1;
                    }
                    else return;
                    break;
                case "2":
                    if (images2.Count > 0)
                    {
                        flag = true;
                        slider.Maximum = images2.Count - 1;
                    image.Source = images2[(int)slider.Value];                  
                    number = 2;
                    }
                    else return;
                    break;
                case "3":
                    if (images3.Count > 0)
                    {
                        flag = true;
                        slider.Maximum = images3.Count - 1;
                    image.Source = images3[(int)slider.Value];     
                    number = 3;
                    }
                    else return;
                    break;
                case "4":
                    if (images4.Count > 0)
                    {
                        flag = true;
                        slider.Maximum = images4.Count - 1;
                    image.Source = images4[(int)slider.Value];
                    number = 4;}
                    else return;
                    break;
                case "5":
                    if (images5.Count > 0)
                    {
                        flag = true;
                        slider.Maximum = images5.Count - 1;
                    image.Source = images5[(int)slider.Value];
                    number = 5;
                    }
                    else return;
                    break;


            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            rb = sender as RadioButton;
            switch(rb.Content.ToString())
            {
                case "1":images1.Add(bitmapImage) ;break;
                case "2": images2.Add(bitmapImage); break;
                case "3": images3.Add(bitmapImage); break;
                case "4": images4.Add(bitmapImage); break;
                case "5": images5.Add(bitmapImage); break;
            } 
        }
    }
}
