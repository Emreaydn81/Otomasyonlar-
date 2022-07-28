using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kütüphane
{
    public partial class Anasayfa : Form
    {
        public Anasayfa()
        {
            InitializeComponent();
        }


        //Çıkış Butonu Kodları
        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Personel Butonu Kodu
        private void personelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Personel frm = new Personel();
            frm.Show();
           
        }

        //Üyeler Buonu Kodu
        private void üyelerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Üyeler frm1 = new Üyeler();
            frm1.Show();
           

        }

        //Kitaplar Butonu Kodu
        private void kitaplarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kitaplar frm2 = new Kitaplar();
            frm2.Show();
        }

        //Emanet Butonu Kodu
        private void emanetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Emanet frm3 = new Emanet();
            frm3.Show();
        }

        //Kullanıcı Butonu Kodu

        private void kullanıcıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kullanıcı frm4 = new Kullanıcı();
            frm4.Show();
        }
    }
}
