﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Carrito_Web
{
    public partial class Carrito : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                repCarrito.DataSource = Session["listaCarrito"];
                repCarrito.DataBind();
        }
    }
}