using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace müsterimodülü
{
    public partial class musterigirisi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    
        protected void Button1_Click(object sender, EventArgs e)
        {
            string kulmail = TextBox1.Text;
            int sifre = Convert.ToInt32(TextBox2.Text);
            bool kontrol = yemeksepeti3.musterivarmi(kulmail,sifre);
            if (kontrol == false)
                Response.Write("YANLIŞ KULLANICI E-MAİLİ VE/VEYA ŞİFRE GİRDİNİZ...");
            else
            {
                Session["OTURUMAC"] = true;
                Session["MÜŞTERİE-MAİL"] = kulmail;
                Response.Redirect("anasayfa.aspx");
            }
        }
    }
}