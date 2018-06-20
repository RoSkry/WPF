using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bind
{
    public class Student : INotifyPropertyChanged
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        private int age;
        public int Age
        {
            set
            {
                age = value;

                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Age"));
            }
            get { return age; }
        }

        public override string ToString()
        {
            return FirstName + " " + LastName + " " + Age;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
