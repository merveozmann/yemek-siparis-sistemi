using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;


namespace YöneticiModülü
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        byte[] resimByte;
        string resimYolu;
        
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
             OpenFileDialog ofd = new OpenFileDialog();
             if (ofd.ShowDialog() == DialogResult.OK)
             {
                 resimYolu = ofd.FileName;
                 FileStream fs = new FileStream(resimYolu, FileMode.Open, FileAccess.Read);
                 BinaryReader br = new BinaryReader(fs);
                 resimByte = br.ReadBytes((int)fs.Length);
                 MessageBox.Show("Resmin bitleri alındı.");
                 pictureBox1.Image = Image.FromFile(resimYolu);
             }
        }

        private void button1_Click(object sender, EventArgs e)
        {
             string ismi = textBox1.Text;
             string turu = textBox2.Text;
             int tel = Convert.ToInt32(textBox3.Text);
             string adres = textBox4.Text;
             byte[] data = resimByte as byte[];
             resimByte = data;
             MemoryStream ms = new MemoryStream();
             ms.Write(data, 0, data.Length);
             Image img = Image.FromStream(ms);
             pictureBox1.Image = img;
           
             yemeksepeti.restoranveriekle(ismi, turu, adres, tel,data);
             MessageBox.Show("EKLENDİ!!!");

           /* SqlConnection baglanti = new SqlConnection(baglantiyolu);
            string sql = "insert into Restoran(restoranismi,restoranturu,adres,telefon,resim) values (@pismi,@pturu,@padr,@ptel,@pres)";
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglanti;
            komut.CommandText = sql;
            komut.Parameters.Clear();
            komut.Parameters.AddWithValue("@pismi", textBox1.Text);
            komut.Parameters.AddWithValue("@pturu", textBox2.Text);
            komut.Parameters.AddWithValue("@padr", textBox4.Text);
            komut.Parameters.AddWithValue("@ptel", textBox3.Text);
            komut.Parameters.AddWithValue("@pres", resimByte);
            baglanti.Open();
            komut.ExecuteNonQuery();
            MessageBox.Show("RESTORAN BİLGİLERİ EKLENDİ!!");
            alanlarisil();
            baglanti.Close();*/
        }

            void alanlarisil()
            {
                textBox1 .Text =null ;
                textBox2.Text=null ;
                textBox3.Text =null;
                textBox4.Text=null;
                resimByte=null ;
            }

            private void textBox5_TextChanged(object sender, EventArgs e)
            {
                
                DataSet bulunanlar = yemeksepeti.bul(textBox5 .Text );
                dataGridView1 .DataSource =bulunanlar .Tables [0];
                //dataGridView1.DataSource =yemeksepeti .vericek ().Tables [0];
            }

            private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {

            }

            private void dataGridView1_SelectionChanged(object sender, EventArgs e)
            {
               
              
            }

            private void button2_Click(object sender, EventArgs e)
            {
                int resid = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                string isim = textBox9.Text;
                string turu = textBox8.Text;
                string adres = textBox6.Text;
                int tel =Convert .ToInt32( textBox7.Text);
                byte[] data = dataGridView1.SelectedRows[0].Cells[5].Value as byte[];
                resimByte = dataGridView1.SelectedRows[0].Cells[5].Value as byte[];
                MemoryStream ms = new MemoryStream();
                ms.Write(data, 0, data.Length);
                Image img = Image.FromStream(ms);
                pictureBox1.Image = img;
                yemeksepeti.düzenle(resid,isim,turu, adres, tel, data);
                MessageBox.Show("RESTORAN BİLGİLERİ DEĞİŞTİRİLDİ...");
                dataGridView1 .DataSource =yemeksepeti .vericek ().Tables [0];
                

              
            }

            private void tabPage3_Click(object sender, EventArgs e)
            {

            }

            private void Form2_Load(object sender, EventArgs e)
            {
             //  dataGridView1 .DataSource =yemeksepeti .vericek ().Tables [0];
            }

            private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    resimYolu = ofd.FileName;
                    FileStream fs = new FileStream(resimYolu, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    resimByte = br.ReadBytes((int)fs.Length);
                    MessageBox.Show("Resmin bitleri alındı.");
                    pictureBox2.Image = Image.FromFile(resimYolu);
                }
            }

            private void button3_Click(object sender, EventArgs e)
            {
                int resid = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                yemeksepeti.sil(resid);
                MessageBox.Show("RESTORAN BİLGİLERİNİZ SİLİNDİ...");
            }

            private void textBox1_TextChanged(object sender, EventArgs e)
            {

            }

            private void dataGridView1_SelectionChanged_1(object sender, EventArgs e)
            {
              
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    textBox9.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                    textBox8.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                    textBox7.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                    textBox6.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                    byte[] data = dataGridView1.SelectedRows[0].Cells[5].Value as byte[];
                    resimByte = data;
                    MemoryStream ms = new MemoryStream();
                    ms.Write(data, 0, data.Length);
                    Image img = Image.FromStream(ms);
                    pictureBox2.Image = img;
                }
            }
        
            

        
       
    }
}

