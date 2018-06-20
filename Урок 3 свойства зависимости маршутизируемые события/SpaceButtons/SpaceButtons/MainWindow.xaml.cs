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

namespace SpaceButtons
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // DependencyProperty и свойство (определяются при задании пробелов для шрифта окна)
        public static readonly DependencyProperty SpaceProperty;
        public int Space
        {
            set
            {
                SetValue(SpaceProperty, value);
            }
            get
            {
                return (int)GetValue(SpaceProperty);
            }
        }

        static MainWindow() // Статический конструктор 
        {
            // Определение метаданных 
            FrameworkPropertyMetadata metadata = new FrameworkPropertyMetadata();
            metadata.Inherits = true;
            // Добавление владельца к SpaceProperty и переопределение метаданных 
            SpaceProperty = SpaceButton.SpaceProperty.AddOwner(typeof(MainWindow));
            SpaceProperty.OverrideMetadata(typeof(MainWindow), metadata);
        }

        public MainWindow()
        {
            InitializeComponent();

            //Title = "Set Space Property";
            //SizeToContent = SizeToContent.WidthAndHeight;
            //ResizeMode = ResizeMode.CanMinimize;
            //int[] iSpaces = { 0, 1, 2 };
            //Grid grid = new Grid();
            //Content = grid;
            //for (int i = 0; i < 2; i++)
            //{
            //    RowDefinition row = new RowDefinition();
            //    row.Height = GridLength.Auto;
            //    grid.RowDefinitions.Add(row);
            //}
            //for (int i = 0; i < iSpaces.Length; i++)
            //{
            //    ColumnDefinition col = new ColumnDefinition();
            //    col.Width = GridLength.Auto;
            //    grid.ColumnDefinitions.Add(col);
            //}
            //for (int i = 0; i < iSpaces.Length; i++)
            //{
            //    SpaceButton btn = new SpaceButton();
            //    btn.Text = "Set window Space to " + iSpaces[i];
            //    btn.Tag = iSpaces[i];
            //    btn.HorizontalAlignment = HorizontalAlignment.Center;
            //    btn.VerticalAlignment = VerticalAlignment.Center;
            //    btn.Click += WindowPropertyOnClick;
            //    grid.Children.Add(btn);
            //    Grid.SetRow(btn, 0);
            //    Grid.SetColumn(btn, i);
            //    btn = new SpaceButton();
            //    btn.Text = "Set button Space to " + iSpaces[i];
            ////    btn.Tag = iSpaces[i];
            //    btn.HorizontalAlignment = HorizontalAlignment.Center;
            //    btn.VerticalAlignment = VerticalAlignment.Center;
            //    btn.Click += ButtonPropertyOnClick;
            //    grid.Children.Add(btn);
            //    Grid.SetRow(btn, 1);
            //    Grid.SetColumn(btn, i);
            //}
        }
        
        void WindowPropertyOnClick(object sender, RoutedEventArgs args)
        {
            SpaceButton btn = args.Source as SpaceButton;
            Space = Convert.ToInt32(btn.Tag);
        }
        void ButtonPropertyOnClick(object sender, RoutedEventArgs args)
        {
            SpaceButton btn = args.Source as SpaceButton;
            btn.Space = Convert.ToInt32(btn.Tag);
        }
    }
}
