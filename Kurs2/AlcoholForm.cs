using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kurs2
{
    public partial class AlcoholForm : Form
    {
        Warehouse W = new Warehouse(); 
        List<Alcohol> Drinks = new List<Alcohol>(); 
                 
        public AlcoholForm(  )
        {
            
            InitializeComponent();
            Alcohol AL = new Alcohol("Тузик", 1, 0.4);
            if (AL.MaxLitres(W) == 0) { MessageBox.Show("На складе недостаточно ингридиентов"); this.Close(); }
            label1.Text = "Спиртные напитки. Максимум: " + Convert.ToString(AL.MaxLitres(W)+" литров ");
            string[] Volumes = { "0,5 литра", "1 литр", "2 литра" };
            listBox1.Items.AddRange(Volumes);
            numericUpDown1.Maximum = AL.MaxLitres(W);
            numericUpDown2.Maximum = 40;
            numericUpDown2.Minimum = 1;
            
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            double v=0;
            switch (listBox1.SelectedIndex)
            {
                case 0:
                    v = 0.5;
                    break;
                case 1:
                    v = 1;
                    break;
                case 2:
                    v = 2;
                    break;
            }
            double sum = (double)numericUpDown1.Value;
            double spirt = (double)numericUpDown2.Value;          
            
            for (int i = 0; i < sum; i++)
            {
                Drinks.Add(new Alcohol("Jack", v, spirt));
                W.GetIngredients(Drinks[i].sugar, Drinks[i].water, spirt, Drinks[i].aroma);
                Drinks[i].Info();
                MessageBox.Show("Произведён напиток: " + Drinks[i].name +", объёмом "+ Drinks[i].mass +" литр(а), крепость: "+ Drinks[i].spirt*100+" %");
            }
        }
         public int GetSum()
        {            
            return Drinks.Count;
        }
    }
}
