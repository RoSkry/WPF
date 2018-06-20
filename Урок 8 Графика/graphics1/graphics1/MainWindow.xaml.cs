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

namespace graphics1
{
    public partial class MainWindow : System.Windows.Window
    {
        // Наш единственный рисующий визуальный объект 
        private DrawingVisual rectVisual = new DrawingVisual();
        private const int NumberOfVisualItems = 1;

        public MainWindow()
        {
            InitializeComponent();
            CreateRectVisual();// Вспомогательная функция для создания прямоугольника 
        }
        private void CreateRectVisual()
        {
            using (DrawingContext drawCtx = rectVisual.RenderOpen())
            {

                // Верхняя, левая, нижняя и правая позиции прямоугольника 
                Rect rect = new Rect(50, 50, 105, 55);
                drawCtx.DrawRectangle(Brushes.AliceBlue, new Pen(Brushes.Blue, 5), rect);
            }

            // Зарегистрируем наш визуальный элемент в дереве объектов, чтобы 
            // гарантировать поддержку маршрутизируемых событий, проверку попадания и 
            AddVisualChild(rectVisual);
            AddLogicalChild(rectVisual);
        }

        // Необходимые переопределения. Графическая система WPF вызовет 
        // это для определения того, сколько элементов надо визуализировать, 
        //и что именно в них визуализировать. 
        protected override int VisualChildrenCount
        {
            get { return NumberOfVisualItems; }
        }

        protected override Visual GetVisualChild(int index)
        {
            // Нумерация элементов в коллекции начинается с нуля, поэтому вычитаем 1. 
            if (index != (NumberOfVisualItems - 1))
                throw new ArgumentOutOfRangeException("index", "Don't have that visual!");
            return rectVisual;
        }
    }
}
