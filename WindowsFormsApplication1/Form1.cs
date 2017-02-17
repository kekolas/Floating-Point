using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        double sayi = 0;
        string donusum1 = "";
        string donusum2= "";
        string ondalik;
        string sign = "0";
        string exponent;
        string mantis;

        public Form1()
        {
            InitializeComponent();
        }
        void ieee754()
        {
            int w = donusum1.Length - 1;
            string yeniDeger = donusum1 + donusum2;
          //  yeniDeger= yeniDeger.Insert(1, ",");
            
            string ex = tamKisimCevir(w + 127);
            yeniDeger = yeniDeger.Substring(1);
            mantis = yeniDeger;
            for (int i = yeniDeger.Length + 1; i <= 23; i++)
            {
                mantis += "0";
            }
 //           Console.WriteLine(ex);
            MessageBox.Show(sign + " " + ex +" "+ mantis);
        }
        string tamKisimCevir(double x)
        {
            //    List<string> k = new List<string>();
            string k = "";
            x = Math.Floor(x);
            while (x >= 1)
            {
                k += (x % 2) +"";
                x = Math.Floor(x / 2);
            }
            k=Reverse(k);
            return k;
        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        string ondalikKisimCevir(double x)
        {
            //    List<string> k = new List<string>();
            string k ="";
            x -= Math.Floor(x);
            while (x != 1)
            {
                x *= 2;
                k += (Math.Floor(x).ToString());
                if (x > 1)
                    x -= 1;
                
            }
            return k;


            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            sayi = Convert.ToDouble(textBox1.Text);
            if (sayi < 0)
                sign = "1";
            sayi = Math.Abs(sayi);
            donusum1 = tamKisimCevir(sayi);
            donusum2 = ondalikKisimCevir(sayi);
            ieee754();
       //     MessageBox.Show(donusum1 + "," + donusum2);
        }

    }
}
