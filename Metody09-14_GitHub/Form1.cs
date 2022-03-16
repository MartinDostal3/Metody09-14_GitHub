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

        int PocetSlov(string retezec, out string novyretezec)
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

       bool ObsahujeSlovo(string retezec, out string nejdelsi, out string nejkratsi)
        {
            bool obsahujeSlovo = false;
            nejdelsi = "";
            nejkratsi = "";
            if (retezec.Length > 0 && retezec != "")
            {
                for (int i = 0; i < retezec.Length && !obsahujeSlovo; i++)
                {
                    if (retezec[i] != ' ') obsahujeSlovo = true;
                }
                if (obsahujeSlovo)
                {
                    char[] separators = { ' ' };
                    string[] s = retezec.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                    nejdelsi = s[0];
                    nejkratsi = s[0];
                    for (int i = 0; i < s.Length; ++i)
                    {
                        string slovicko = s[i];
                        if (slovicko.Length < nejkratsi.Length) nejkratsi = slovicko;
                        if (slovicko.Length > nejdelsi.Length) nejdelsi = slovicko;
                    }
                }
            }
            return obsahujeSlovo;
        }
        bool JeAlfanum(string retezec, out int pocMal, out int pocVel, out int pocJin)
        {
            pocMal = 0;
            pocVel = 0;
            pocJin = 0;
            bool jeAlfanum = true;
            for (int i = 0; i < retezec.Length; i++)
            {
                if (char.IsNumber(retezec[i])) { }
                else if (char.IsLower(retezec[i])) pocMal++;
                else if (char.IsUpper(retezec[i])) pocVel++;
                else
                {
                    jeAlfanum = false;
                    pocJin++;
                }
            }
            return jeAlfanum;
        }

        bool Identicke(string retezec1, string retezec2, out int odlisujiciPozice, out int indexPrvni)
        {
            odlisujiciPozice = 0;
            indexPrvni = -1;
            bool identicke = false;
            if (retezec1 == retezec2) identicke = true;
            else
            {
                bool prvniOdlisnost = false;
                identicke = false;
                if (retezec1.Length > retezec2.Length)
                {
                    string pomocny = retezec1;
                    retezec1 = retezec2;
                    retezec2 = pomocny;
                }
                for (int i = 0; i < retezec1.Length - 1; ++i)
                {
                    if (retezec1[i] != retezec2[i])
                    {
                        odlisujiciPozice++;
                        if (!prvniOdlisnost)
                        {
                            indexPrvni = i;
                            prvniOdlisnost = true;
                        }
                    }
                }
                if (!prvniOdlisnost) indexPrvni = retezec1.Length;
                odlisujiciPozice += (retezec2.Length - retezec1.Length);
            }
            return identicke;
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
            string s = "Ahoj jak8 2se Msa1";
            string novyretezec = "";
            MessageBox.Show("Počet slov je: " + PocetSlov(s, out novyretezec) + "\nŘetězec bez číslic: " + novyretezec);
        }

        private void button4_Click(object sender, EventArgs e)
        {

            string s = textBox1.Text;
            string nejdelsi = "";
            string nejkratsi = "";
            if (ObsahujeSlovo(s, out nejdelsi, out nejkratsi)) MessageBox.Show("Text obsahuje slovo\nNejdelší slovo je: " + nejdelsi + "\nNejkratší slovo je: " + nejkratsi);
            else MessageBox.Show("Žádná slova");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int pocVel;
            int pocMal;
            int pocJin;
            string s = "Ahoj jak8 2se Msa1";
            if (JeAlfanum(s, out pocMal, out pocVel, out pocJin)) MessageBox.Show("Řetězec je alfanum\nPoc mal:" + pocMal + "\nPoc vel:" + pocVel + "\nPoc jin:" + pocJin);
            else MessageBox.Show("Řetězec není alfanumerický\nPoc mal:" + pocMal + "\nPoc vel:" + pocVel + "\nPoc jin:" + pocJin);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string s1 = "Ahoj jak8 2se Msa1";
            string s2 = "Ahoj";
            int odlisPoz = 0;
            int prvniIndex = 0;
            if (Identicke(s1, s2, out odlisPoz, out prvniIndex)) MessageBox.Show("Řetězce jsou identické");
            else MessageBox.Show("Řetězce nejsou identické\nPočet odlišností: " + odlisPoz + "\nPrvní index odlišnosti: " + prvniIndex);
        }
    } 
}

