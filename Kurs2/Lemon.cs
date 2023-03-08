using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Kurs2
{
    class Lemon : Drink, InterDrink
    {
        public double gas;
        public double kras;
        public Lemon(string name, double mass, double gas) : base(name, mass)
        {
            this.name = name;
            this.gas = (mass * gas) / 100;
            this.mass = mass;
            water = mass * 0.5;
            sugar = mass * 0.06;
            aroma = mass * 0.09;
            kras = mass*0.05;
        }
        public int MaxLitres(Warehouse W1)
        {
            double max = 1000;
            if (max > W1.Gas / gas) { max = W1.Gas / gas; }
            if (max > W1.Water / water) { max = W1.Water / water; }
            if (max > W1.Sugar / sugar) { max = W1.Sugar / sugar; }
            if (max > W1.Aroma / aroma) { max = W1.Aroma / aroma; }
            if (max > W1.Kras / kras) { max = W1.Kras / kras; }
            return Convert.ToInt32(max);
        }
        public void Info()
        {
            File.AppendAllText("Отчет.txt", Environment.NewLine + "Напиток " + name + " объёмом " + mass + " газированость: " + gas);
        }
        public string GetSpecies()
        {
            string i = null;
            if (gas > 0.04) { i = "Сильногазированый"; }
            if (gas <= 0.04) { i = "Среднегазированый"; }
            if (gas <= 0.02) { i = "Слабогазированый"; }            
            return i;
        }
        
    }
}
