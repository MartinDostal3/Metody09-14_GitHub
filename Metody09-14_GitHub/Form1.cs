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
            double x1, x2;
            double vysledekD;
            vysledekD = Math.Pow(b, 2) - (4 * a * c);
            if (vysledekD > 0)
            {
                x1 = (-b + Math.Sqrt(vysledekD)) / (2 * a);
                x2 = (-b - Math.Sqrt(vysledekD)) / (2 * a);
            }
            else if (vysledekD == 0)
            {
                x1 = (-b - Math.Sqrt(vysledekD)) / (2 * a);

            }
            return vysledekD;

        }
        bool obsahujeCislici(string retezec, out int cifSoucet, out int cifSoucetLich, out int cifSoucetSud)
        {
            int cifra;
            cifSoucet = 0;
            cifSoucetSud = 0;
            cifSoucetLich = 0;
            bool obsahuje = false;
            for (int i = 0; i < retezec.Length; ++i)
            {
                if (char.IsNumber(retezec[i]))
                {
                    obsahuje = true;
                    cifra = int.Parse(retezec[i].ToString());
                    cifSoucet += cifra;
                    if (cifra % 2 == 0) cifSoucetSud += cifra;
                    else cifSoucetLich += cifra;
                }
            }
            return obsahuje;
        }

        int PocetSlov1(string retezec, out string novyretezec)
        {
            string novyretezec1 = retezec;
            char[] separators = { ' ' };
            string[] s = novyretezec1.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            int pocetSlov = s.Length;
            int i = 0;
            while (i < retezec.Length)
            {
                if (char.IsNumber(retezec[i]))
                {
                    retezec = retezec.Remove(i, 1);
                }
                else ++i;

            }
            novyretezec = retezec;
            return pocetSlov;
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


            if (diskrimi == 0)
            {
                MessageBox.Show("Rovnice ma reseni v R");
            }
            else MessageBox.Show("Rovnice nema reseni v R");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string s = "Ahoj jak8 2se Msa1";
            int cifSoucet;
            int cifSoucetLich;
            int cifSoucetSud;
            if (obsahujeCislici(s, out cifSoucet, out cifSoucetLich, out cifSoucetSud)) MessageBox.Show("Obsahuje číslici\nCif Sou. je: " + cifSoucet + "\nCif. Sou. Lich. je: " + cifSoucetLich + "\nCif. Sou. Sud.: " + cifSoucetSud);
            else MessageBox.Show("Neobsahuje číslo");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string s = "Ahoj 5já jsem 1 matěj12";
            string novyretezec = "";
            MessageBox.Show("Počet slov je: " + PocetSlov1(s, out novyretezec) + "\nŘetězec bez číslic: " + novyretezec);
        }

    } 
}

