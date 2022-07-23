using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;//sqpl kütüphane kodları

namespace Kütüphane_Otomasyon
{
    public partial class Form7 : Form
    {
        SqlConnection baglan = new SqlConnection("Data Source=Emreaydn81\\sqlexpress;Initial Catalog=Kütüphane;Integrated Security=True");
        DataSet ds = new DataSet();
        SqlDataAdapter adtr = new SqlDataAdapter();
        SqlCommand komut = new SqlCommand();

        public object Kütüphane { get; private set; }

        //Kullanıcı Giriş DataGridviewe Verileri Çekme
        void Listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from Kullanıcı", baglan);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Kullanıcı.DataSource = dt;
        }
        public Form7()
        {
            InitializeComponent();
            Listele();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            Listele();
        }

        //Arama Kısmı
        private void button3_Click(object sender, EventArgs e)
        {
            baglan = new SqlConnection("Data Source=Emreaydn81\\sqlexpress;Initial Catalog=Kütüphane;Integrated Security=True");
            adtr = new SqlDataAdapter("Select * from Kullanıcı where Adı like '" + textBox3.Text + "%'", baglan);
            ds = new DataSet();
            baglan.Open();
            adtr.Fill(ds, "Kullanıcı");
            Kullanıcı.DataSource = ds.Tables["Kullanıcı"];
            baglan.Close();
        }

        //Ekleme Kısmı Butonu
        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult c;
            c = MessageBox.Show("Eklemek istediğinizden emin misiniz?", "Uyarı!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (c == DialogResult.Yes)
            {
                komut.Connection = baglan;
                komut.CommandText = "Insert Into Kullanıcı(Adı,Sifre) Values ('" + textBox1.Text + "','" + textBox2.Text + "')";
                baglan.Open();
                komut.ExecuteNonQuery();
                komut.Dispose();
                baglan.Close();
                MessageBox.Show("Kayıt Tamamlandı!");
                ds.Clear();
                Listele();


            }
            else
            {
                MessageBox.Show("Kayıt Yapılamadı!");
            }
        }
    

        //Silme Kısmı
        private void button1_Click(object sender, EventArgs e)
        {

            DialogResult c;
            c = MessageBox.Show("Silmek istediğinizden emin misiniz?", "Uyarı!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (c == DialogResult.Yes)
            {

                ds = new DataSet();
                string sorgu = "DELETE FROM Kullanıcı WHERE Adı=@A";
                komut = new SqlCommand(sorgu, baglan);
                komut.Parameters.AddWithValue("@A", textBox1.Text);
                baglan.Open();
                komut.ExecuteNonQuery();
                MessageBox.Show("Silme İşlemi Tamamlandı!");
                baglan.Close();
                ds.Clear();
                Listele();
            }
            else
            {
                MessageBox.Show("Silme İşlemi Tamamlanamadı!");
            }
        }


        //Güncelleme Kısmı
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult c;
            c = MessageBox.Show("Güncellemek istediğinizden emin misiniz?", "Uyarı!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (c == DialogResult.Yes)
            {
                baglan.Open();
                komut.Connection = baglan;
                komut.CommandText = ("update Kullanıcı SET Adı=@A,Sifre=@S where Adı=@A");
                komut.Parameters.AddWithValue("@A", textBox1.Text);
                komut.Parameters.AddWithValue("@S", textBox2.Text);
                MessageBox.Show("Güncelleme İşlemi Tamamlandı!");
                komut.ExecuteNonQuery();
                baglan.Close();
                Listele();
            }
            else
            {
                MessageBox.Show("Güncelleme İşlemi Tamamlanamadı!");
            }
        }

        //Anasayfa Kısmı
        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        
        //Textbox Temizleme
        private void button7_Click_1(object sender, EventArgs e)
        {
            var nesneler = groupBox1.Controls.OfType<TextBox>();
            var nesnelerr = groupBox2.Controls.OfType<TextBox>();
            foreach (var nesne in nesneler)
            {
                nesne.Clear();
            }
            foreach (var nesnee in nesnelerr)
            {
                nesnee.Clear();
            }
        }

        //Datagrid Tıklayınca Verileri Textboxa cekme
        private void Kullanıcı_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = Kullanıcı.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = Kullanıcı.CurrentRow.Cells[1].Value.ToString();
        }
    }
}
