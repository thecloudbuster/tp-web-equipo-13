using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Carrito_Web.Clases;
using dominio;
using gestor;


namespace Carrito_Web
{
    public partial class DetalleArticulo : System.Web.UI.Page
    {
        public string id { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
        }
    }
}