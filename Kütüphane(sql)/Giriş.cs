using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;//Kütüphane Dosyası

namespace Kütüphane
{
    public partial class Giriş : Form
    {
        public Giriş()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        //Giriş Butonu Koldarı
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("Data Source=Emreaydn81\\sqlexpress;Initial Catalog=Kütüphane;Integrated Security=True");
            //access bağlantıyı sağladık
            SqlCommand komut = new SqlCommand("select * from Kullanıcı where Adı='" + textBox1.Text + "' and Sifre ='" + textBox2.Text + "'", baglanti);
            //access komutumuzu yazdık komutta veritabanındaki admin tablosunda kullanıcı adı textbox1.text olan şifresi textbox2.text olan veriyi
            // çekmesini istedik
            baglanti.Open();//bağlantıyı açdık

            SqlDataReader oku = komut.ExecuteReader();//veriyi okutma emrini verdik
            if (oku.Read())//if eğer veriyi okumuşsa yani böyle bir kullanıcı veritabanında kayıtlıysa
            {
                MessageBox.Show("Giriş Başarılı !");//giriş başarılı diye uyari verir
                baglanti.Close();//bağlantıyı kapar
                Anasayfa menu = new Anasayfa();//yeni bir menü sayfası oluşturur
                menu.Show();//menü sayfasını açar
                this.Hide();////mevcut sayfayı gizler

            }
            else
            {
                MessageBox.Show("Kullanıcı Adınız Yada Şifreniz Yanlış Yazılmıştır");//hayır veri okuyamadıysa uyarı verir
                textBox1.Text = "";
                textBox2.Text = "";
                //verileri temizler
            }
        }

        //Çıkış Butonu Kodlar
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
