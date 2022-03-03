using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Metody09_14_GitHub
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        double diskriminant(double a, double b, double c)
        {
            double vysledekD;
            vysledekD = Math.Pow(b, 2) - (4 * a * c);
            return vysledekD;

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double a = double.Parse(textBox1.Text);
            double b = double.Parse(textBox2.Text);
            double c = double.Parse(textBox3.Text);
            double diskrimi = diskriminant(a, b, c);
            MessageBox.Show("Diskriminant je: " + diskrimi);

        }
    }
}
