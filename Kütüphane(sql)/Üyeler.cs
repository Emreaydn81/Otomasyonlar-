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
    public partial class Üyeler : Form
    {
        SqlConnection baglan = new SqlConnection("Data Source=Emreaydn81\\sqlexpress;Initial Catalog=Kütüphane;Integrated Security=True");
        DataSet ds = new DataSet();
        SqlDataAdapter adtr = new SqlDataAdapter();
        SqlCommand komut = new SqlCommand();

        public object Kütüphane { get; private set; }

        //Datagrid listeleme
        void listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from Üyeler", baglan);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        public Üyeler()
        {
            InitializeComponent();
            listele();
        }

        private void Üyeler_Load(object sender, EventArgs e)
        {

        }

        //Çıkış Butonu Kodları
        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Arama Butonu Kodları
        private void aramaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            baglan = new SqlConnection("Data Source=Emreaydn81\\sqlexpress;Initial Catalog=Kütüphane;Integrated Security=True");
            adtr = new SqlDataAdapter("Select * from Üyeler where Ögr_No like '" + textBox5.Text + "%'", baglan);
            ds = new DataSet();
            baglan.Open();
            adtr.Fill(ds, "Üyeler");
            dataGridView1.DataSource = ds.Tables["Üyeler"];
            baglan.Close();
        }

        //Arama Butonu Kodları
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

        //Güncelle Butonu Kodları
        private void güncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult c;
            c = MessageBox.Show("Güncellemek istediğinizden emin misiniz?", "Uyarı!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (c == DialogResult.Yes)
            {
                baglan.Open();
                komut.Connection = baglan;
                komut.CommandText = ("update Üyeler SET Ögr_No=@Ö,Adı=@A,Soyadı=@S,Telefon=@T where Ögr_No=@Ö");
                komut.Parameters.AddWithValue("@Ö", textBox1.Text);
                komut.Parameters.AddWithValue("@A", textBox2.Text);
                komut.Parameters.AddWithValue("@S", textBox3.Text);
                komut.Parameters.AddWithValue("@T", textBox4.Text);
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

        //Sil Butonu Kodları
        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DialogResult c;
            c = MessageBox.Show("Silmek istediğinizden emin misiniz?", "Uyarı!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (c == DialogResult.Yes)
            {

                ds = new DataSet();
                string sorgu = "DELETE FROM Üyeler WHERE Ögr_No=@Ö";
                komut = new SqlCommand(sorgu, baglan);
                komut.Parameters.AddWithValue("@Ö", textBox1.Text);
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

        //Ekle Butonu Kodları
        private void ekleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult c;
            c = MessageBox.Show("Eklemek istediğinizden emin misiniz?", "Uyarı!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (c == DialogResult.Yes)
            {
                komut.Connection = baglan;
                komut.CommandText = "Insert Into Üyeler(Ögr_No,Adı,Soyadı,Telefon) Values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
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

        //Datagrid üzerinde veriye tıklayınca textboxlarda yazdırma
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }
    }
}
