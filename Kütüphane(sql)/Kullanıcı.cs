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

namespace Kütüphane
{
    public partial class Kullanıcı : Form
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
            dataGridView1.DataSource = dt;
        }
        public Kullanıcı()
        {
            InitializeComponent();
            Listele();
        }

        private void Kullanıcı_Load(object sender, EventArgs e)
        {

        }

        //Arama Butonu Kısmı Kodları

        private void aramaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            baglan = new SqlConnection("Data Source=Emreaydn81\\sqlexpress;Initial Catalog=Kütüphane;Integrated Security=True");
            adtr = new SqlDataAdapter("Select * from Kullanıcı where Adı like '" + textBox3.Text + "%'", baglan);
            ds = new DataSet();
            baglan.Open();
            adtr.Fill(ds, "Kullanıcı");
            dataGridView1.DataSource = ds.Tables["Kullanıcı"];
            baglan.Close();
        }

        //Ekle Butonu Kodları
        private void ekleToolStripMenuItem_Click(object sender, EventArgs e)
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

        //Silme Butonu Kıdmı Kodları
        private void silToolStripMenuItem_Click(object sender, EventArgs e)
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

        //Güncelle Butonu Kodları
        private void güncelleToolStripMenuItem_Click(object sender, EventArgs e)
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

        //Anasayfa Butonu Kodları
        private void anasayfaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        //Temizle Butonu Kodları
        private void temizleToolStripMenuItem_Click(object sender, EventArgs e)
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
        //datagrid üzerinde veriye tıklayınca verileri textboxta gösterme

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }
    }
}
