using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Bind
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Student> Students { get; set; }

        Student student;

        public MainWindow()
        {
            InitializeComponent();
            Students = new ObservableCollection<Student>
            {
                new Student{FirstName="Иван", LastName="Петров",Age=23},
                new Student{FirstName="Петр", LastName="Иванов",Age=21}
            };
        }

        private void change_Click(object sender, RoutedEventArgs e)
        {
            //if (list.SelectedIndex!=-1)
            //{
            //    ((Student)list.SelectedItem).Age++;

            //    foreach (Student item in Students)
            //    {
            //        MessageBox.Show(item.ToString());
            //    }
            //}

            if (student != null)
            {
                student.Age++;
            }
        }

        private void dgStudents_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                student = (Student)dgStudents.SelectedItem;
            }
            catch { }
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            Students.Add(new Bind.Student { FirstName = "John", LastName = "Doe", Age = 30 });
        }
    }
}