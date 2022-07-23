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
    public partial class Form6 : Form
    {
        SqlConnection baglan = new SqlConnection("Data Source=Emreaydn81\\sqlexpress;Initial Catalog=Kütüphane;Integrated Security=True");
        DataSet ds = new DataSet();
        SqlDataAdapter adtr = new SqlDataAdapter();
        SqlCommand komut = new SqlCommand();

        public object Kütüphane { get; private set; }

        //Emanet Datagridview Lİsteleme
        void Listele()
         {
            SqlDataAdapter da = new SqlDataAdapter("Select * from Emanet", baglan);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Emanett.DataSource = dt;
        }
    public Form6()
        {
            InitializeComponent();
            Listele();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            Listele();
            comboBox1.Items.Add("Ögr_No");
            comboBox1.Items.Add("Kitap_Adı");
            comboBox1.SelectedIndex = 0;

        }


        //Ekleme Kısmı
        private void button4_Click(object sender, EventArgs e)
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
                Listele();

            }
            else
            {
                MessageBox.Show("Kayıt Yapılamadı!");
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
                Listele();
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
                string sorgu = "DELETE FROM Emanet  WHERE Ögr_No=@No";
                komut = new SqlCommand(sorgu, baglan);
                komut.Parameters.AddWithValue("@No", textBox1.Text);
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
       

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //Arama Butonu
        private void button3_Click_1(object sender, EventArgs e)
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


        //DataGrid'e Tıklayınca kayıtları Textbox'lara yazdırma bölümü
        private void Emanet_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
