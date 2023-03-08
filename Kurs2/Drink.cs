using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurs2
{
    abstract class Drink
    {
        public string name;
        public double mass;
        public double water;
        public double sugar;
        public double aroma;
        public Drink(string name, double mass)
        {
            this.name = name;
            this.mass = mass;   
        }
    }
}
