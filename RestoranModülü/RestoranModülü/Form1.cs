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

namespace RestoranModülü
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
      

        private void Form1_Load(object sender, EventArgs e)
        {
            DataSet restoran = new DataSet();
            restoran = yemeksepeti2.restorancek();
            comboBox1.DisplayMember = "restoranismi";
            comboBox1.ValueMember = "restoranid";
            comboBox1 .DataSource =restoran.Tables [0];
        }
        public static int restoranid;
        private void button1_Click(object sender, EventArgs e)
        {
            
            restoranid = Convert.ToInt32(comboBox1 .SelectedValue);
            Form2 frm = new Form2();
            frm.Show();
            this.Hide();
        }
    }
}
