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
    public partial class JuiceForm : Form
    {
        Warehouse W = new Warehouse();
        List<Juice> Drinks = new List<Juice>();
        
        public JuiceForm()
        {
            InitializeComponent();
            Juice JU = new Juice("Тузик", 1, 0.4);
            if (JU.MaxLitres(W) == 0) { MessageBox.Show("На складе недостаточно ингридиентов"); this.Close(); }
            label1.Text = "Соки. Максимум: " + Convert.ToString(JU.MaxLitres(W) + " литров ");
            string[] Volumes = { "0,5 литра", "1 литр", "2 литра" };
            listBox1.Items.AddRange(Volumes);
            numericUpDown1.Maximum = JU.MaxLitres(W);
            numericUpDown2.Maximum = 10;
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
            double juicekoncetr = (double)numericUpDown2.Value;
            

            for (int i = 0; i < sum; i++)
            {
                Drinks.Add(new Juice("Добрый", v, juicekoncetr));
                W.GetIngredients(Drinks[i].sugar, Drinks[i].water, juicekoncetr);
                Drinks[i].Info();
                MessageBox.Show("Произведён напиток: " + Drinks[i].name + ", объёмом " + Drinks[i].mass + " литр(а), концетрация сока: " + Drinks[i].juicekoncetr*100 + " %");
            }
            

        }
        public int GetSum()
        {           
            return Drinks.Count;
        }
    }
}
