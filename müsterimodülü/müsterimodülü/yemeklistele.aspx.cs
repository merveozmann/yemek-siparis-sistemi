using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace müsterimodülü
{
    public partial class yemeklistele : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((bool)Session["OTURUMAC"] == true)
            {
                if (IsPostBack == false)
                {
                    Response.Write("MERHABA SEVGİLİ ÜYEMİZ");
                    DropDownList1.DataTextField = "restoranismi";
                    DropDownList1.DataValueField = "restoranid";
                    DropDownList1.DataSource = yemeksepeti3.restorancek().Tables[0];
                    DropDownList1.DataBind();
                }
                
            }
            else
                Response.Redirect("anasayfa.aspx");

           
        }


        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int resid=Convert.ToInt32(DropDownList1.SelectedValue);
            GridView1.DataSource = null;
            GridView1.DataBind();
            DropDownList2.DataTextField = "kategoriadi";
            DropDownList2.DataValueField = "kategoriid";
            DropDownList2.DataSource = yemeksepeti3.kategoricekk(resid).Tables[0];
            DropDownList2.DataBind();
           
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            int restoranid=Convert .ToInt32 (DropDownList1.SelectedValue);
            int katid=Convert.ToInt32 (DropDownList2.SelectedValue);
            GridView1.DataSource = null;
            GridView1.DataBind();
            GridView1.DataSource =yemeksepeti3.yemekcek (restoranid,katid).Tables [0];
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "GOSTER")
            {
                int yemekid=Convert.ToInt32 (Session ["opsiyonid"]);
                Session["opsiyonid"] = Convert.ToInt32(e.CommandArgument);
                GridView2.DataSource = yemeksepeti3.opsiyoncek (yemekid ).Tables [0];
                GridView2.DataBind();
            }
        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EKLE")
            {
                Session["yemekopsiyonid"] = Convert.ToInt32(e.CommandArgument);
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
           
            int musteriid = Convert.ToInt32(Session["musteriid"]);
            int restoranid =Convert.ToInt32(DropDownList1.SelectedValue);
            int yemekid = Convert.ToInt32(Session ["opsiyonid"]);
            int yemekopsiyonid = Convert.ToInt32(Session ["yemekopsiyonid"]);
            yemeksepeti3.sepetekle(musteriid,restoranid,yemekid,yemekopsiyonid);
            Response.Write("YEMEKLER SEPETE EKLENDİ...");

        }
    }
}