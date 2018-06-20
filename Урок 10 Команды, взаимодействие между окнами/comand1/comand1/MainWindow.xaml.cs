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

namespace comand1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Клавиатурный жест Control+F 
            InputGesture gesture = new KeyGesture(Key.F, ModifierKeys.Control, "Ctrl+F");
            ApplicationCommands.Find.InputGestures.Add(gesture);

            // Комбинированный жест Control+LeftClick
            gesture = new MouseGesture(MouseAction.LeftClick, ModifierKeys.Control);
            ApplicationCommands.Find.InputGestures.Add(gesture);

            // Клавиатурный жест Control+Q
            KeyGesture keyGesture = new KeyGesture(Key.Q, ModifierKeys.Control, "Ctrl+Q");
            ApplicationCommands.Find.InputGestures.Add(keyGesture);

            // Комбинированный жест Alt+LeftClick
            MouseGesture mouseGesture = new MouseGesture();
            mouseGesture.MouseAction = MouseAction.LeftClick;
            mouseGesture.Modifiers = ModifierKeys.Alt;
            ApplicationCommands.Find.InputGestures.Add(mouseGesture);
        }
        System.Windows.Forms.OpenFileDialog openFileDialog = null;
        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (openFileDialog == null)
                openFileDialog = new System.Windows.Forms.OpenFileDialog();

            openFileDialog.ShowDialog();
        }

       

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Shift+Q");
            ApplicationCommands.Open.Execute(null, Butt);
        }

        private void FindCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Find");
            isDirty = true;
            CommandManager.InvalidateRequerySuggested();
        }

        private void CommandBinding_CloseExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("MyClose");
        }

        bool isDirty;

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = isDirty;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            isDirty = true;

            if (string.IsNullOrEmpty(textBox.Text))
            {
                isDirty = false;
            }
        }
    }
}
