using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace Kurs2
{
    public partial class Form1 : Form
    {       
        public Form1()
        {             
            InitializeComponent();
            string[] Drunks = { "Лимонад", "Спиртные напитки", "Сок" };
            listBox1.Items.AddRange(Drunks);            
        }

        public void button1_Click(object sender, EventArgs e)
        {
            AlcoholForm AlF = new AlcoholForm();
            LemonForm LmF = new LemonForm();
            JuiceForm JuF = new JuiceForm();
            try
            {
                switch (listBox1.SelectedIndex)
                {
                    case 0:
                        LmF.ShowDialog();
                        label1.Text = Convert.ToString(Convert.ToInt32(label1.Text) + LmF.GetSum());
                        break;
                    case 1:
                        AlF.ShowDialog();
                        label2.Text = Convert.ToString(Convert.ToInt32(label2.Text) + AlF.GetSum());
                        break;
                    case 2:
                        JuF.ShowDialog();
                        label3.Text = Convert.ToString(Convert.ToInt32(label3.Text) + JuF.GetSum());
                        break;
                }
            }
            catch { MessageBox.Show("Пополните содержимое склада"); Application.Exit(); }
        }
    }
}
