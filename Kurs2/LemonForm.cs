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
    public partial class LemonForm : Form
    {
        Warehouse W = new Warehouse();
        List<Lemon> Drinks = new List<Lemon>();
       
        public LemonForm()
        {
            InitializeComponent();
            Lemon LE = new Lemon("Тузик", 1, 0.4);
            if (LE.MaxLitres(W) == 0) { MessageBox.Show("На складе недостаточно ингридиентов"); this.Close(); }
            label1.Text = "Лимонады. Максимум: " + Convert.ToString(LE.MaxLitres(W) + " литров ");
            string[] Volumes = { "0,5 литра", "1 литр", "2 литра" };
            listBox1.Items.AddRange(Volumes);
            numericUpDown1.Maximum = LE.MaxLitres(W);
            numericUpDown2.Maximum = 7;
            numericUpDown2.Minimum = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double v = 0;
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
            double gas = (double)numericUpDown2.Value;
            

            for (int i = 0; i < sum; i++)
            {
                Drinks.Add(new Lemon("Золотой ключик", v, gas));
                W.GetIngredients(Drinks[i].sugar, Drinks[i].water, gas, Drinks[i].aroma, Drinks[i].kras);
                Drinks[i].Info();
                MessageBox.Show("Произведён напиток: " + Drinks[i].name + ", объёмом " + Drinks[i].mass + " литр(а), газированость: " + Drinks[i].GetSpecies() );
            }
            

        }
        public int GetSum()
        {   
            return Drinks.Count;
        }
    }
}
