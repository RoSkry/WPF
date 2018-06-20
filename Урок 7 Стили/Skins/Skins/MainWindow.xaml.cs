using System;
using System.Windows;

namespace Skins
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
            ResourceDictionary ResDirectionary = new ResourceDictionary();
            ResDirectionary.Source = new Uri("Skins/Skin2.xaml", UriKind.RelativeOrAbsolute);
            //ResourceDictionary ResDirectionary = (ResourceDictionary)Application.LoadComponent(new Uri("Skins/Skin2.xaml", UriKind.Relative));
            //Application.Current.Resources = ResDirectionary; // изменяется в Application

            mainWindow.Resources = ResDirectionary; // изменяется в окне

            lb1.Content = "Skins_Green";
        }
    }
}
