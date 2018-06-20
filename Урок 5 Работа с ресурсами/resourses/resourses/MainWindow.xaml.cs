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
using System.Windows.Resources;
using System.Windows.Shapes;

namespace resourses
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //DirectoryInfo directoryInfo = new DirectoryInfo(Environment.CurrentDirectory + "/Img");
            //DirectoryInfo[] directories = directoryInfo.GetDirectories();

            //FileInfo fileInfo = new FileInfo(directoryInfo + "/bear.jpg");
            //BitmapImage bitmapImage = new BitmapImage(new Uri(fileInfo.FullName));

            //BitmapImage bitmapImage = new BitmapImage(new Uri(System.IO.Path.GetFullPath(@"Images/bear.jpg")));
            //img.Source = bitmapImage;
            //img.Source = new BitmapImage(new Uri("Images/Winter.jpg",UriKind.Relative));

            //Sound.Stop();
            //Sound.Play();
           

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            StreamResourceInfo streamResourceInfo = Application.GetResourceStream(new Uri("Images/fon.png", UriKind.Relative));
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.StreamSource = streamResourceInfo.Stream;
            bitmapImage.EndInit();
            this.Background = new ImageBrush(bitmapImage);
        }
    }
}
