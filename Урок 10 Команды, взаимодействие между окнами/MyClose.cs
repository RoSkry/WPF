using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace WpfApp1
{
    class MyClose
    {
        public static RoutedUICommand Close
        {
            get;
        }
        
        static MyClose()
        {
            // Инициализация команды. 
            InputGestureCollection inputs = new InputGestureCollection();
            inputs.Add(new KeyGesture(Key.R, ModifierKeys.Control, "Ctrl+R"));
            Close = new RoutedUICommand("Requery", "Requery", typeof(MyClose), inputs);
        }
    }
}
