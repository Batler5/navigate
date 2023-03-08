using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Kurs2
{
    class Alcohol : Drink, InterDrink

    {
        public double spirt;
        public Alcohol(string name, double mass, double spirt) : base(name, mass)
        {
            this.name = name;
            this.spirt = spirt / 100;
            this.mass = mass;
            water = mass * 0.6;
            sugar = mass * 0.02;
            aroma = mass * 0.08;

        }
        public int MaxLitres(Warehouse W1)
        {
            double max = 1000;
            if (max > W1.Spirt / spirt) { max = W1.Spirt / spirt; }
            if (max > W1.Water / water) { max = W1.Water / water; }
            if (max > W1.Sugar / sugar) { max = W1.Sugar / sugar; }
            if (max > W1.Aroma / aroma) { max = W1.Aroma / aroma; }
            return Convert.ToInt32(max);
        }
        public void Info()
        {
            File.AppendAllText("Отчет.txt", Environment.NewLine + "Напиток " + name + " объёмом " + mass + "литров, крепость: " + spirt*100);
        }
        
    }
}
