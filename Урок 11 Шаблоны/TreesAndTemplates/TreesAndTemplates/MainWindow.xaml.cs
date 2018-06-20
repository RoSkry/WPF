using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

using System.Reflection;
using System.Xml;
using System.Windows.Markup;

namespace TreesAndTemplates
{
    // +++++++++++++++++++++++ WPF_McDonald стр. 438 ++++++++++++++++++++++++++++++++
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Type controlType = typeof(Control);
            List<Type> derivedTypes = new List<Type>();

            // Выполняем поиск всех типов в сборке, где определен класс Control
            Assembly assembly = Assembly.GetAssembly(typeof(Control));
            foreach (Type type in assembly.GetTypes())
            {
                // Добавляем тип в список только в том случае, если он представляет 
                // конкретный класс Control и является общедоступным
                if (type.IsSubclassOf(controlType) && !type.IsAbstract && type.IsPublic)
                {
                    derivedTypes.Add(type);
                }
            }

            // Сортируем типы в алфавитном порядке по имени с помощью специального класса TypeComparer
            derivedTypes.Sort(new TypeComparer());

            // Заполняем список типов
            txtFullName.ItemsSource = derivedTypes;
            
            // Показываем первый тип в списке
            txtFullName.Text = txtFullName.Items[0].ToString();
        }

        public class TypeComparer : IComparer<Type>
        {
            public int Compare(Type x, Type y)
            {
                return x.Name.CompareTo(y.Name);
            }
        }

        /*+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++*/

        private StringBuilder dataToShow = new StringBuilder();

        private void btnShowLogicalTree_Click(object sender, RoutedEventArgs e)
        {
            dataToShow.Clear();
            BuildLogicalTree(0, this);
            this.txtDisplayArea.Text = dataToShow.ToString();
        }

        private void BuildLogicalTree(int depth, object obj)
        {
            // Добавить имя типа к переменной-члену dataToShow.
            dataToShow.Append(new string(' ', depth) + obj.GetType().Name + "\n");

            // DependencyObject - Представляет объект, участвующий в системе свойств зависимостей, см. DependencyObject - класс.txt
            // Если элемент - не DependencyObject, пропустить его. 
            if (!(obj is DependencyObject))
                return;
            // Выполнить рекурсивный вызов для каждого дочернего элемента логического дерева 
            foreach (object child in LogicalTreeHelper.GetChildren(obj as DependencyObject))
                BuildLogicalTree(depth + 5, child);
        }

        /*+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++*/

        private void btnShowVisualTree_Click(object sender, RoutedEventArgs e)
        {
            dataToShow.Clear();
            BuildVisualTree(0, this);
            this.txtDisplayArea.Text = dataToShow.ToString();
        }

        private void BuildVisualTree(int depth, DependencyObject obj)
        {
            // Добавить имя типа к переменной-члену dataToShow.
            dataToShow.Append(new string(' ', depth) + obj.GetType().Name + "\n");

            // Выполнить рекурсивный вызов для каждого дочернего элемента визуального дерева 
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
                BuildVisualTree(depth + 1, VisualTreeHelper.GetChild(obj, i));
        }

        /*+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++*/

        private Control ctrlToExamine = null;

        private void btnTemplate_Click(object sender, RoutedEventArgs e)
        {
            dataToShow.Clear();
            ShowTemplate();
            this.txtDisplayArea.Text = dataToShow.ToString();
        }
        private void ShowTemplate()
        {
            // Удалить элемент управления, находящийся в области предварительного просмотра. 
            if (ctrlToExamine != null)
                stackTemplatePanel.Children.Remove(ctrlToExamine);
            try
            {
                // Загрузить сборку PresentationFramework и создать экземпляр 
                // указанного элемента управления. Задать его размер для отображения, 
                // затем добавить пустую панель StackPanel. 
                Assembly asm = Assembly.Load("PresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35");
                ctrlToExamine = (Control)asm.CreateInstance(txtFullName.Text);
                ctrlToExamine.Height = 200;
                ctrlToExamine.Width = 200;
                ctrlToExamine.Margin = new Thickness(5);
                stackTemplatePanel.Children.Add(ctrlToExamine);
                
                
                // Определить некоторые настройки XML для сохранения отступов. 
                XmlWriterSettings xmlSettings = new XmlWriterSettings();
                xmlSettings.Indent = true;
                
                // Создать XmlWriter на основе существующих настроек. 
                XmlWriter xWriter = XmlWriter.Create(dataToShow, xmlSettings);
                // Сохранить XAML-разметку в объекте XmlWriter на основе ControlTemplate. 
                XamlWriter.Save(ctrlToExamine.Template, xWriter);

                /*
                
                // сохранение Control в строке
                string savedControl = XamlWriter.Save(ctrlToExamine);

                // загрузка Control
                System.IO.StringReader stringReader = new System.IO.StringReader(savedControl);
                XmlReader xmlReader = XmlReader.Create(stringReader);
                Control readerLoadControl = (Control)XamlReader.Load(xmlReader);
                stackTemplatePanel.Children.Add(readerLoadControl);
                
                 */
            }
            catch (Exception ex)
            {
                dataToShow.Append(ex.Message);
            }
        }
    }
}