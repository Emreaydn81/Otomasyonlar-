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
    public partial class Form4 : Form
    {
        SqlConnection baglan = new SqlConnection("Data Source=Emreaydn81\\sqlexpress;Initial Catalog=Kütüphane;Integrated Security=True");
        DataSet ds = new DataSet();
        SqlDataAdapter adtr = new SqlDataAdapter();
        SqlCommand komut = new SqlCommand();

        public object Kütüphane { get; private set; }

        //Datagrid listeleme
        void listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from Personel", baglan);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Personel.DataSource = dt;
        }
        public Form4()
        {
            InitializeComponent();
            listele();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            listele();
        }

        //Arama Kısmı
        private void button3_Click(object sender, EventArgs e)
        {
            {
                baglan = new SqlConnection("Data Source=Emreaydn81\\sqlexpress;Initial Catalog=Kütüphane;Integrated Security=True");
                adtr = new SqlDataAdapter("Select * from Personel where Adı like '" + textBox5.Text + "%'", baglan);
                ds = new DataSet();
                baglan.Open();
                adtr.Fill(ds, "Personel");
                Personel.DataSource = ds.Tables["Personel"];
                baglan.Close();

            }
        }

        //Ekle Butonu Kısmı
        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult c;
            c = MessageBox.Show("Eklemek istediğinizden emin misiniz?", "Uyarı!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (c == DialogResult.Yes)
            {
                komut.Connection = baglan;
                komut.CommandText = "Insert Into Personel(Adı,Soyadı,Telefon) Values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')";
                baglan.Open();
                komut.ExecuteNonQuery();
                komut.Dispose();
                baglan.Close();
                MessageBox.Show("Kayıt Tamamlandı!");
                ds.Clear();
                listele();


            }
            else
            {
                MessageBox.Show("Kayıt Yapılamadı!");
            }
        }

        //Güncelle Kısmı
        private void button2_Click(object sender, EventArgs e)
        {

            DialogResult c;
            c = MessageBox.Show("Güncellemek istediğinizden emin misiniz?", "Uyarı!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (c == DialogResult.Yes)
            {
                baglan.Open();
                komut.Connection = baglan;
                komut.CommandText = ("update Personel SET Adı=@A,Soyadı=@S,Telefon=@T where Adı=@A");
                komut.Parameters.AddWithValue("@A", textBox1.Text);
                komut.Parameters.AddWithValue("@S", textBox2.Text);
                komut.Parameters.AddWithValue("@T", textBox3.Text);
                MessageBox.Show("Güncelleme İşlemi Tamamlandı!");
                komut.ExecuteNonQuery();
                baglan.Close();
                listele();
            }
            else
            {
                MessageBox.Show("Güncelleme İşlemi Tamamlanamadı!");
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
                string sorgu = "DELETE FROM Personel WHERE Adı=@A";
                komut = new SqlCommand(sorgu, baglan);
                komut.Parameters.AddWithValue("@A", textBox1.Text);
                baglan.Open();
                komut.ExecuteNonQuery();
                MessageBox.Show("Silme İşlemi Tamamlandı!");
                baglan.Close();
                ds.Clear();
                listele();
            }
            else
            {
                MessageBox.Show("Silme İşlemi Tamamlanamadı!");
            }

        }

         //Textbox Temizleme 
        private void button7_Click(object sender, EventArgs e)
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

        //AnaSayfa Kısmı
        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

       
        //DataGrid'e Tıklayınca kayıtları Textbox'lara yazdırma bölümü
     
      private void Personel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = Personel.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = Personel.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = Personel.CurrentRow.Cells[2].Value.ToString();
        }
    }
}
