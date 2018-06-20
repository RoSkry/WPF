using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        List<ImageSource> images1, images2, images3, images4, images5;//для хранения фотографий по оценкам
       
        DirectoryInfo directoryInfo;
        FileInfo fileInfo;
        BitmapImage bitmapImage;
        RadioButton rb;
        bool flag = false;//для работы  слайдера после фильтра
        int number = 0;
        string[] names= { "Arrow-wood.jpg",
                      "Fir-tree.jpg",
                       "Oak.jpg",
                       "Poplar.jpg",
                       "Willow.jpg",
                        "Rose.jpg",
                       "Tulip.jpg",
                        "Camomile.jpg",
                        "Dandelion.jpg" };
        public MainWindow()
        {
            InitializeComponent();
            images1 = new List<ImageSource>();
            images2 = new List<ImageSource>();
            images3 = new List<ImageSource>();
            images4 = new List<ImageSource>();
            images5 = new List<ImageSource>();
            directoryInfo = new DirectoryInfo(Environment.CurrentDirectory + "/Images");
          
          
            fileInfo = new FileInfo(directoryInfo + $"/Arrow-wood.jpg");

        bitmapImage = new BitmapImage(new Uri(fileInfo.FullName));
            name.Text = fileInfo.Name;
            date.Text = fileInfo.CreationTime.ToShortDateString();
            image.Source = bitmapImage;

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            directoryInfo = new DirectoryInfo(Environment.CurrentDirectory + "/Images");
            switch (list.SelectedIndex)
            {
                case 0: fileInfo = new FileInfo(directoryInfo + $"/Arrow-wood.jpg"); break;
                case 1: fileInfo = new FileInfo(directoryInfo + $"/Fir-tree.jpg"); break;
                case 2: fileInfo = new FileInfo(directoryInfo + $"/Oak.jpg"); break;
                case 3: fileInfo = new FileInfo(directoryInfo + $"/Poplar.jpg"); break;
                case 4: fileInfo = new FileInfo(directoryInfo + $"/Willow.jpg"); break;
                case 5: fileInfo = new FileInfo(directoryInfo + $"/Rose.jpg"); break;
                case 6: fileInfo = new FileInfo(directoryInfo + $"/Tulip.jpg"); break;
                case 7: fileInfo = new FileInfo(directoryInfo + $"/Camomile.jpg"); break;
                case 8: fileInfo = new FileInfo(directoryInfo + $"/Dandelion.jpg"); break;
            }
            name.Text = fileInfo.Name;
            date.Text = fileInfo.CreationTime.ToShortDateString();
            bitmapImage = new BitmapImage(new Uri(fileInfo.FullName));
            image.Source = bitmapImage;
            if (rb != null) rb.IsChecked = false;

        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
           

           if (!flag)
            image.Source = bitmapImage;
            else Choosesource(number);
          

            //  //убирает метку радиобатона при переходе на следующую картинку
            if (rb != null) rb.IsChecked = false;
        }
        ////метод для выбора картинок в фильтре

        public void Choosesource(int count)
        {
            switch (count)
            {
                case 1: image.Source = images1[(int)slider.Value]; break;
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
            ComboBox combo = sender as ComboBox;
            ComboBoxItem selectedItem = (ComboBoxItem)combo.SelectedItem;
            slider.Value = 0;

            switch (selectedItem.Content.ToString())
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
                        number = 4;
                    }
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

        private void findbtn_Click(object sender, RoutedEventArgs e)
        {
            string search = srctxt.Text+".jpg";
            if (srctxt1.Text.Length > 0) search = srctxt1.Text + ".jpg";
            bool r = true;
            for(int i=0;i<names.Length;i++)
            {
                if(search==names[i])
                { 
                    fileInfo = new FileInfo(directoryInfo + $"/{search}");
                    image.Source= new BitmapImage(new Uri(fileInfo.FullName));
                    r = false;
                }
            }
            if (r) MessageBox.Show("Ничего не найдено");
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files(*.BMP, *.JPG, *.GIF, *.TIF, *.PNG, *.ICO, *.EMF, *.WMF)| *.bmp; *.jpg; *.gif; *.tif; *.png; *.ico; *.emf; *.wmf)";
            if (openFileDialog.ShowDialog() == true)
            {
                using (var stream = new FileStream(openFileDialog.FileName, FileMode.Open))
                {
                    image.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                }
                openFileDialog.ShowDialog();
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JPG Files (*.jpg)|*.jpg";
            if (saveFileDialog.ShowDialog() == true)
            {
                JpegBitmapEncoder jpegBitmapEncoder = new JpegBitmapEncoder();
                jpegBitmapEncoder.Frames.Add(BitmapFrame.Create(image.Source as BitmapSource));
                using (FileStream fileStream = new FileStream(saveFileDialog.FileName, FileMode.Create))
                    jpegBitmapEncoder.Save(fileStream);
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            rb = sender as RadioButton;
            switch (rb.Content.ToString())
            {
                case "1(Awful)": images1.Add(bitmapImage); break;
                case "2(Bad)": images2.Add(bitmapImage); break;
                case "3(Normal)": images3.Add(bitmapImage); break;
                case "4(Good)": images4.Add(bitmapImage); break;
                case "5(Perfect)": images5.Add(bitmapImage); break;
            }
        }

        private void firstbtn_Click(object sender, RoutedEventArgs e)
        {
            slider.Value = 0;
        }

        private void lastbtn_Click(object sender, RoutedEventArgs e)
        {
            slider.Value = slider.Maximum;
        }

        private void TreeViewItem_Selected(object sender, RoutedEventArgs e)
        {
            TreeViewItem tr = sender as TreeViewItem;
          
           
            switch (tr.Header)
            {
                case "Fir-tree": fileInfo = new FileInfo(directoryInfo + $"/Fir-tree.jpg"); break;
                case "Willow": fileInfo = new FileInfo(directoryInfo + $"/Willow.jpg");  break;
                case "Arrow-wood": fileInfo = new FileInfo(directoryInfo + $"/Arrow-wood.jpg"); break;
                case "Oak": fileInfo = new FileInfo(directoryInfo + $"/Oak.jpg");  break;
                case "Poplar": fileInfo = new FileInfo(directoryInfo + $"/Poplar.jpg");  break;
                case "Rose": fileInfo = new FileInfo(directoryInfo + $"/Rose.jpg"); break;
                case "Tulip": fileInfo = new FileInfo(directoryInfo + $"/Tulip.jpg"); break;
                case "Camomile": fileInfo = new FileInfo(directoryInfo + $"/Camomile.jpg"); break;
                case "Dandelion": fileInfo = new FileInfo(directoryInfo + $"/Dandelion.jpg"); break;
            }
            image.Source = new BitmapImage(new Uri(fileInfo.FullName)); 
        }

     
    }
}
