using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kütüphane_Otomasyon
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        //Form4 Geçiş Buton Kodu(Personel Formu)
        private void button2_Click(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4();
            frm4.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        //Form3 Geçiş Buton Kodu(Üyeler Formu)
        private void button1_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.Show();
        }

        //Form5 Geçiş Buton Kodu(Kitaplar Formu)
        private void button3_Click(object sender, EventArgs e)
        {
            Form5 frm5 = new Form5();
            frm5.Show();
        }

        //Form6 Geçiş Buton Kodu(Emanet Verilenler Formu)
        private void button4_Click(object sender, EventArgs e)
        {
            Form6 frm6 = new Form6();
            frm6.Show();
        }

        //Form7 Geçiş Buton Kodu(Kullanıcı Giriş Formu)
        private void button5_Click(object sender, EventArgs e)
        {
            Form7 frm7 = new Form7();
            frm7.Show();
        }

        //Çıkış Butonu Kodu
        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
