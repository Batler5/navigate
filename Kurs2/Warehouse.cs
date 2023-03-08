using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Kurs2
{
    public class Warehouse
    {
        double sugar;     
        double water;
        double spirt;
        double aroma;
        double gas;
        double kras;
        double juicekoncetr;
        List<string> ingr = new List<string>();
        List<double> ingrmass = new List<double>();
        
        public Warehouse()
        {
            
            string path = @"a.txt";
            StreamReader sr = new StreamReader(path);
            string text = sr.ReadToEnd();
            sr.Close();
            string[] s = text.Split('\n');            
            string[] g = new string[2];          
            for (int i = 0; i < s.Length; i++)
            {
                g = s[i].Split('=');
                try
                {
                    if (Convert.ToDouble(g[1]) <= 0)
                    {
                        break;
                    }
                }
                catch { }
                switch (g[0])
                {
                    case "sugar": sugar = Convert.ToDouble(g[1]); break;
                    case "water": water = Convert.ToDouble(g[1]); break;
                    case "spirt": spirt = Convert.ToDouble(g[1]); break;
                    case "aroma": aroma = Convert.ToDouble(g[1]); break;
                    case "gas": gas = Convert.ToDouble(g[1]); break;
                    case "juicekoncetr": juicekoncetr = Convert.ToDouble(g[1]); break;
                    case "kras": kras = Convert.ToDouble(g[1]);break;
                    case "":return;
                }
                ingr.Add(g[0]);
                ingrmass.Add(Convert.ToDouble(g[1]));
                
            }
           // ingrmass2 = ingrmass;
        }

        public void GetIngredients(double sugar, double water, double spirt, double aroma)
        {
            string path = @"a.txt";
            StreamReader sr = new StreamReader(path);            
            string text = sr.ReadToEnd();
            sr.Close();
            StreamWriter sw = new StreamWriter(path);
            string[] s = text.Split('\n');
            string[,] a = new string[99, 2];
            string[] g = new string[2];
            
            for (int i = 0; i < ingr.Count; i++)
            {                
                switch (ingr[i])
                {
                    case "sugar": ingrmass[i]-= sugar;                        
                             break;
                    case "water": ingrmass[i] -= water;
                        break;
                    case "spirt": ingrmass[i] -= spirt/100;
                        break;
                    case "aroma": ingrmass[i] -= aroma;
                        break;
                    case "gas":ingrmass[i] = gas;
                        break;
                    case "juicekoncetr": ingrmass[i] = juicekoncetr;
                                            break;
                    case "kras": ingrmass[i] = kras;break;
                }
                
            }
            for (int i = 0; i < ingr.Count ; i++)
            {
                sw.WriteLine(ingr[i]+"="+ingrmass[i]);
            }
                sw.Close();
           // InfoIngr();
        }
        public void GetIngredients(double sugar, double water, double gas, double aroma, double kras)
        {
            string path = @"a.txt";
            StreamReader sr = new StreamReader(path);
            string text = sr.ReadToEnd();
            sr.Close();
            StreamWriter sw = new StreamWriter(path);
            string[] s = text.Split('\n');
            string[,] a = new string[99, 2];
            string[] g = new string[2];

            for (int i = 0; i < ingr.Count; i++)
            {
                switch (ingr[i])
                {
                    case "sugar":
                        ingrmass[i] -= sugar;
                        break;
                    case "water":
                        ingrmass[i] -= water;
                        break;
                    case "spirt":
                        ingrmass[i] = spirt;
                        break;
                    case "aroma":
                        ingrmass[i] -= aroma;
                        break;
                    case "gas":
                        ingrmass[i] -= gas/100;
                        break;
                    case "juicekoncetr":
                        ingrmass[i] = juicekoncetr;
                        break;
                    case "kras": ingrmass[i] -= kras; 
                        break;
                }
            }
            for (int i = 0; i < ingr.Count; i++)
            {
                sw.WriteLine(ingr[i] + "=" + ingrmass[i]);
            }
            sw.Close();
           // InfoIngr();
        }
        public void GetIngredients(double sugar, double water, double juicekoncetr)
        {
            string path = @"a.txt";
            StreamReader sr = new StreamReader(path);
            string text = sr.ReadToEnd();
            sr.Close();
            StreamWriter sw = new StreamWriter(path);
            string[] s = text.Split('\n');
            string[,] a = new string[99, 2];
            string[] g = new string[2];

            for (int i = 0; i < ingr.Count; i++)
            {
                switch (ingr[i])
                {
                    case "sugar":
                        ingrmass[i] -= sugar;
                        break;
                    case "water":
                        ingrmass[i] -= water;
                        break;
                    case "spirt":
                        ingrmass[i] = spirt;
                        break;
                    case "aroma":
                        ingrmass[i] = aroma;
                        break;
                    case "gas":
                        ingrmass[i] = gas;
                        break;
                    case "juicekoncetr":
                        ingrmass[i] -= juicekoncetr/100;
                        break;
                    case "kras": ingrmass[i] = kras; break;
                }

            }
            for (int i = 0; i < ingr.Count; i++)
            {
                sw.WriteLine(ingr[i] + "=" + ingrmass[i]);
            }
            sw.Close();
           // InfoIngr();
        }
       /* public void InfoIngr()
        {
            
            // Отчет Затраты ингредиентов
            string path = @"ОтчетИнгр.txt";
            StreamReader sr = new StreamReader(path);
            string text = sr.ReadToEnd();
            sr.Close();
            string[] s = text.Split('\n');
            string[] g = new string[2];
            List<string> ingrmassOt = new List<string>();
            List<string> ingrOt = new List<string>();
            for (int i = 0; i < s.Length; i++)
            {
                g = s[i].Split('=');
               
                switch (g[0])
                {
                    case "sugar": g[1]= Convert.ToString(Convert.ToDouble(g[1])+(ingrmass2[0]-ingrmass[0])); break;
                    case "water": g[1] = Convert.ToString(Convert.ToDouble(g[1]) + (ingrmass2[1] - ingrmass[1])); break;
                    case "spirt": g[1] = Convert.ToString(Convert.ToDouble(g[1]) + (ingrmass2[2] - ingrmass[2])); break;
                    case "aroma": g[1] = Convert.ToString(Convert.ToDouble(g[1]) + (ingrmass2[3] - ingrmass[3])); break;
                    case "gas": g[1] = Convert.ToString(Convert.ToDouble(g[1]) + (ingrmass2[4] - ingrmass[4])); break;
                    case "juicekoncetr": g[1] = Convert.ToString(Convert.ToDouble(g[1]) + (ingrmass2[5] - ingrmass[5])); break;
                    case "kras": g[1] = Convert.ToString(Convert.ToDouble(g[1]) + (ingrmass2[6] - ingrmass[6])); break;
                    case "": return;
                }
                
                ingrOt.Add(g[0]);
                
                ingrmassOt.Add(g[1]);
            }
            StreamWriter sw = new StreamWriter(path);
            for (int i = 0; i < ingrOt.Count; i++)
            {
                sw.WriteLine(ingrOt[i] + "=" + ingrmassOt[i]);
            }
            sw.Close();
        }*/
        public double Sugar { get { return sugar; } set { sugar = value; } }
        public double Water { get { return water; } set { water = value; } }
        public double Spirt { get { return spirt; } set { spirt = value; } }
        public double Aroma { get { return aroma; } set { aroma = value; } }
        public double Gas { get { return gas; } set { gas = value; } }
        public double Juicekoncetr { get { return juicekoncetr; } set { juicekoncetr = value; } }
        public double Kras { get { return kras; } set { kras = value; } }


    }
}
