﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace müsterimodülü
{
    public partial class kategorilistele : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataSource =yemeksepeti3.kategoricek ().Tables [0];
            GridView1.DataBind();
        }
    }
}