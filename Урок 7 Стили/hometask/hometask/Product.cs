using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hometask
{
    class Product
    {
       public  string  Name { get; set; }
        public double  Count { get; set; }
        public double   Price { get; set; }
        public double RealPrice { get; set; }
        public bool   Purchased { get; set; }
        public int  Code { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }

    

}
