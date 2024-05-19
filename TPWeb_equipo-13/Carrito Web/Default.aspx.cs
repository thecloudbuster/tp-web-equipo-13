﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using gestor;

namespace Carrito_Web
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["listaArticulo"] == null) { 
            gestionArticulo gestionArt = new gestionArticulo();
            Session.Add("listaArticulo", gestionArt.listar());
            }
        }
    }
    
}