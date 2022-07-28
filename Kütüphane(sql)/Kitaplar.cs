using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Kütüphane
{

    public partial class Kitaplar : Form
    {
        SqlConnection baglan = new SqlConnection("Data Source=Emreaydn81\\sqlexpress;Initial Catalog=Kütüphane;Integrated Security=True");
        DataSet ds = new DataSet();
        SqlDataAdapter adtr = new SqlDataAdapter();
        SqlCommand komut = new SqlCommand();

        public object Kütüphane { get; private set; }

        //Datagrid listeleme
        void listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from Kitaplar", baglan);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        public Kitaplar()
        {
            InitializeComponent();
            listele();
        }

        //Çıkış Butonu Kodları
        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Arama Butonu Kodları
        private void aramaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                baglan = new SqlConnection("Data Source=Emreaydn81\\sqlexpress;Initial Catalog=Kütüphane;Integrated Security=True");

                dataGridView1.RefreshEdit();
                if (comboBox1.Text == "Kitap_Adı")
                {
                    adtr = new SqlDataAdapter("Select * from Kitaplar where Kitap_Adı like '" + textBox4.Text.Trim() + "%'", baglan);
                    ds = new DataSet();
                    adtr.Fill(ds, "Kitaplar");
                    dataGridView1.DataSource = ds.Tables["Kitaplar"];

                }

                else if (comboBox1.Text == "Yazar")

                {
                    adtr = new SqlDataAdapter("Select * from Kitaplar where Yazar like '" + textBox4.Text.Trim() + "%'", baglan);
                    ds = new DataSet();
                    adtr.Fill(ds, "Kitaplar");
                    dataGridView1.DataSource = ds.Tables["Kitaplar"];

                }

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

        //Güncelle Butonu Kodları
        private void güncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult c;
            c = MessageBox.Show("Güncellemek istediğinizden emin misiniz?", "Uyarı!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (c == DialogResult.Yes)
            {
                baglan.Open();
                komut.Connection = baglan;
                komut.CommandText = ("update Kitaplar SET Kitap_Kodu=@Kitap_Kodu,Kitap_Adı=@Kitap_Adı,Kitap_Rafı=@Kitap_Rafı,Yazar=@Yazar,Türü=@Türü,Stoklar=@Stoklar where Kitap_Kodu=@Kitap_Kodu");
                komut.Parameters.AddWithValue("@Kitap_Kodu", textBox1.Text);
                komut.Parameters.AddWithValue("@Kitap_Adı", textBox2.Text);
                komut.Parameters.AddWithValue("@Kitap_Rafı", textBox3.Text);
                komut.Parameters.AddWithValue("@Yazar", textBox6.Text);
                komut.Parameters.AddWithValue("@Türü", textBox7.Text);
                komut.Parameters.AddWithValue("@Stoklar", textBox5.Text);
                komut.ExecuteNonQuery();
                MessageBox.Show("Güncelleme Tamamlandı!");
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
                string sorgu = "DELETE FROM Kitaplar WHERE Kitap_Kodu=@Kitap_Kodu";
                komut = new SqlCommand(sorgu, baglan);
                komut.Parameters.AddWithValue("@Kitap_Kodu", textBox1.Text);
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

        //Datagrid üzerinde verilerden birine tıklayınca textboxta yazdırma
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        //Ekle Butonu Kodları
        private void ekleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "")
            {
                komut.Connection = baglan;
                komut.CommandText = "Insert Into Kitaplar(Kitap_Kodu,Kitap_Adı,Kitap_Rafı,Yazar,Türü,Stoklar) Values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox5.Text + "')";
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

        //Combobox içine veri yazma
        private void Kitaplar_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Kitap_Adı");
            comboBox1.Items.Add("Yazar");
            comboBox1.SelectedIndex = 0;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
