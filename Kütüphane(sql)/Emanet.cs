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
    public partial class Emanet : Form
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
            Emanett.DataSource = dt;
        }
        public Emanet()
        {
            InitializeComponent();
            listele();
        }

        private void Emanet_Load(object sender, EventArgs e)
        {
            
            comboBox1.Items.Add("Ögr_No");
            comboBox1.Items.Add("Kitap_Adı");
            comboBox1.SelectedIndex = 0;
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
                {
                    baglan = new SqlConnection("Data Source=Emreaydn81\\sqlexpress;Initial Catalog=Kütüphane;Integrated Security=True");

                    Emanett.RefreshEdit();
                    if (comboBox1.Text == "Ögr_No")
                    {
                        adtr = new SqlDataAdapter("Select * from Emanet where Ögr_No like '" + textBox6.Text.Trim() + "%'", baglan);
                        ds = new DataSet();
                        adtr.Fill(ds, "Emanet");
                        Emanett.DataSource = ds.Tables["Emanet"];

                    }

                    else if (comboBox1.Text == "Kitap_Adı")

                    {
                        adtr = new SqlDataAdapter("Select * from Emanet where Kitap_Adı like '" + textBox6.Text.Trim() + "%'", baglan);
                        ds = new DataSet();
                        adtr.Fill(ds, "Emanet");
                        Emanett.DataSource = ds.Tables["Emanet"];

                    }

                }
            }
        }

        //Anasayfa butonu Kodları
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
                komut.CommandText = ("update Emanet  SET Ögr_No=@No,Üye_Adı=@Adı,Üye_Soyadı=@Soyadı,Kitap_Adı=@Kitap_Adı,Üye_Telefon=@Telefon,Alış_Tarihi=@Alış,Veriş_Tarihi=@Veriş where Ögr_No=@No");
                komut.Parameters.AddWithValue("@No", textBox1.Text);
                komut.Parameters.AddWithValue("@Adı", textBox2.Text);
                komut.Parameters.AddWithValue("@Soyadı", textBox3.Text);
                komut.Parameters.AddWithValue("@Kitap_Adı", textBox4.Text);
                komut.Parameters.AddWithValue("@Telefon", textBox5.Text);
                komut.Parameters.AddWithValue("@Alış", dateTimePicker1.Value);
                komut.Parameters.AddWithValue("@Veriş", dateTimePicker2.Value);
                komut.ExecuteNonQuery();
                MessageBox.Show("Güncelleme İşlemi Tamamlandı !");
                baglan.Close();
                listele();
            }
            else
            {
                MessageBox.Show("Güncelleme İşlemi Tamamlanamadı!");
            }
        }

        //Sil Butonu Kodu
        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult c;
            c = MessageBox.Show("Silmek istediğinizden emin misiniz?", "Uyarı!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (c == DialogResult.Yes)
            {

                ds = new DataSet();
                string sorgu = "DELETE FROM Emanet  WHERE Ögr_No=@No";
                komut = new SqlCommand(sorgu, baglan);
                komut.Parameters.AddWithValue("@No", textBox1.Text);
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
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox5.Text != "" && textBox4.Text != "" && dateTimePicker1.Text != "" && dateTimePicker2.Text != "")
            {
                komut.Connection = baglan;
                komut.CommandText = "Insert Into Emanet (Ögr_No,Üye_Adı,Üye_Soyadı,Kitap_Adı,Üye_Telefon,Alış_Tarihi,Veriş_Tarihi) Values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + dateTimePicker1.Value + "','" + dateTimePicker2.Value + "')";
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

        //Datagrid üzerinde veriye tıklayınca verileri textboxta gösterme 
        private void Emanett_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = Emanett.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = Emanett.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = Emanett.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = Emanett.CurrentRow.Cells[4].Value.ToString();
            textBox5.Text = Emanett.CurrentRow.Cells[3].Value.ToString();
            dateTimePicker1.Text = Emanett.CurrentRow.Cells[5].Value.ToString();
            dateTimePicker2.Text = Emanett.CurrentRow.Cells[6].Value.ToString();
        }
    }
}
