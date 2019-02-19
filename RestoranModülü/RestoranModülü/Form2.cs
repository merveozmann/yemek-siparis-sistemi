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

namespace RestoranModülü
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        byte[] resimByte;
        string resimYolu;

        private void button1_Click(object sender, EventArgs e)
        {

            string adi = textBox1.Text;
            string aciklama = textBox2.Text;
            int resid = Form1.restoranid;
            int katid = Convert.ToInt32(comboBox1.SelectedValue);
            yemeksepeti2.kategoriekle(adi,aciklama,resid,katid);
            dataGridView1.DataSource = yemeksepeti2.kategoricek().Tables [0];
            comboBox1.DataSource =yemeksepeti2.kategoricek().Tables [0];
            MessageBox.Show("KATEGORİ BİLGİLERİ EKLENDİ...");

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void fiyat_TextChanged(object sender, EventArgs e)
        {

        }

        private void sure_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
      
        private void button4_Click(object sender, EventArgs e)
        {
            string ismi = textBox6.Text;
            int hazsur = Convert.ToInt32(textBox13.Text);
            int fiyat = Convert.ToInt32(textBox14.Text);
            byte[] data =resimByte as byte[];
            resimByte = data;
            MemoryStream ms = new MemoryStream();
            ms.Write(data, 0, data.Length);
            Image img = Image.FromStream(ms);
            pictureBox2.Image = img;
            string aciklama = textBox12.Text;
            int kategoriid = Convert.ToInt32(comboBox1.SelectedValue);
            int resid = Form1.restoranid;
            yemeksepeti2.yemekekle(kategoriid ,ismi,hazsur,fiyat,data,aciklama,resid);
            dataGridView2.DataSource = yemeksepeti2.yemekcek().Tables [0];
            comboBox1.DataSource = yemeksepeti2.kategoricek().Tables[0];
            MessageBox.Show("YEMEK BİLGİLERİ EKLENDİ...");
            
        }

        private void adi_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
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

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void aciklama_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }
        public static int resid;
       
        private void Form2_Load(object sender, EventArgs e)
        {
           
            DataSet restoran = new DataSet();
            restoran = yemeksepeti2.kategoricek ();
            comboBox1.DisplayMember = "kategoriadi";
            comboBox1.ValueMember = "kategoriid";
            comboBox1.DataSource = restoran.Tables[0]; 
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            DataSet bulunan = yemeksepeti2.bul (textBox3.Text );
            dataGridView1.DataSource =bulunan .Tables [0];

        }
      
        private void button2_Click(object sender, EventArgs e)
        {
            int katid = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            string adi = textBox4.Text;
            string aciklama = textBox5.Text;
            yemeksepeti2.kategoriduzenle(katid,adi,aciklama);
            MessageBox.Show("YENİ BİLGİLER GÜNCELLENDİ...");
        }
        
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                textBox4.Text = dataGridView1.SelectedRows[0].Cells[1].Value .ToString();
                textBox5.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            int kategoriid = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            yemeksepeti2.kategorisil(kategoriid);
            MessageBox.Show("KATEGORİ TABLOSUNDAKİ KAYITLAR SİLİNDİ...");
        }
         
        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            DataSet bulunan=yemeksepeti2 .yemekbul(textBox7.Text );
            dataGridView2 .DataSource =bulunan .Tables [0];
        }

        private void DÜZENLE_Click(object sender, EventArgs e)
        {
            int yemekid = (int)dataGridView2.SelectedRows[0].Cells[0].Value;
            string ismi = textBox10.Text;
            int hazsure = Convert.ToInt32(textBox8.Text);
            int fiyat = Convert.ToInt32(textBox9.Text );
            byte[] data = resimByte as byte[];
            resimByte = data;
            MemoryStream ms = new MemoryStream();
            ms.Write(data, 0, data.Length);
            Image img = Image.FromStream(ms);
            pictureBox2.Image = img;
            string aciklama = textBox11.Text;
            int katid = Convert.ToInt32 ( comboBox1.SelectedValue);
            yemeksepeti2.yemekduzenle(yemekid,katid,ismi,hazsure,fiyat,data,aciklama);
            MessageBox.Show("YEMEK BİLGİLERİ GÜNCELLENDİ...");

        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                comboBox1.Text = dataGridView2.SelectedRows[0].Cells[1].Value.ToString();
                textBox10.Text = dataGridView2.SelectedRows[0].Cells[2].Value.ToString();
                textBox8.Text = dataGridView2.SelectedRows[0].Cells[3].Value.ToString();
                textBox9.Text = dataGridView2.SelectedRows[0].Cells[4].Value.ToString();
                byte[] data = dataGridView2.SelectedRows[0].Cells[5].Value as byte[];
                resimByte = data;
                MemoryStream ms = new MemoryStream();
                ms.Write(data, 0, data.Length);
                Image img = Image.FromStream(ms);
                pictureBox2.Image = img;
                textBox11.Text = dataGridView2.SelectedRows[0].Cells[6].Value.ToString();
            }

        }
       
        private void SİL_Click(object sender, EventArgs e)
        {
            int yemekid=(int)dataGridView2 .SelectedRows [0].Cells [0].Value ;
            yemeksepeti2 .yemeksil (yemekid);
            MessageBox .Show ("YEMEKLER SİLİNDİ...");

        }
        
        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
      
         void opsiyon()
        {
            comboBox3.DisplayMember = "opsiyonadi";
            comboBox3.ValueMember = "yemekopsiyonid";
            comboBox3.DataSource = yemeksepeti2.opsiyoncek1(Convert.ToInt32(dataGridView2.SelectedRows[0].Cells[0].Value)).Tables [0];
           
 
        }
        private void button5_Click_1(object sender, EventArgs e)
        {
            string isim = textBox15.Text;
            int fiyat = Convert.ToInt32(textBox16.Text);
            int yemekid = (int)dataGridView2.SelectedRows[0].Cells[0].Value;
            int resid = Convert.ToInt32(Form1.restoranid);
            yemeksepeti2.opsiyonekle(isim,fiyat,yemekid,resid);
            MessageBox.Show("OPSİYON EKLENDİ...");
            opsiyon();
        }
        
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox17.Text = yemeksepeti2.opsiyoncek(Convert.ToInt32(dataGridView2.SelectedRows[0].Cells[0].Value), Convert.ToInt32(comboBox3.SelectedValue)).Tables[0].Rows[0][1].ToString();
            textBox18.Text = yemeksepeti2.opsiyoncek(Convert.ToInt32(dataGridView2.SelectedRows[0].Cells[0].Value), Convert.ToInt32(comboBox3.SelectedValue)).Tables[0].Rows[0][2].ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            string adi = textBox17.Text;
            int fiyati = Convert.ToInt32(textBox18.Text);
            int id = Convert.ToInt32(comboBox3.SelectedValue);
            yemeksepeti2.opsiyonguncelle(adi,fiyati,id);
            MessageBox.Show("YEMEK OPSİYONLARI GÜNCELLENDİ...");
            opsiyon();

        }
       
        private void button7_Click(object sender, EventArgs e)
        {
            int opid = Convert.ToInt32(comboBox3.SelectedValue);
            yemeksepeti2.opsiyonsil(opid);
            MessageBox.Show("OPSİYON KAYITLARI SİLİNDİ!!");
            opsiyon();
        }
    }
}
