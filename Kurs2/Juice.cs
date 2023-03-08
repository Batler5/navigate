using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Kurs2
{
    class Juice : Drink, InterDrink
    {
        public double juicekoncetr;
        
        public Juice(string name, double mass, double juicekoncetr) : base(name, mass)
        {
            this.name = name;
            this.juicekoncetr = (mass * juicekoncetr) / 100;
            this.mass = mass;
            water = mass * 0.8;
            sugar = mass * 0.1;         
            
        }
        public int MaxLitres(Warehouse W1)
        {
            double max = 1000;            
            if (max > W1.Water / water) { max = W1.Water / water; }
            if (max > W1.Sugar / sugar) { max = W1.Sugar / sugar; }
            if (max > W1.Juicekoncetr / juicekoncetr) { max = W1.Juicekoncetr / juicekoncetr; }
            return Convert.ToInt32(max);
        }
        public void Info()
        {
            
            File.AppendAllText("Отчет.txt", Environment.NewLine + "Напиток " + name + " объёмом " + mass + " концетрат сока: " + juicekoncetr);
        }
    }
}
