using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Carrito_Web
{
    public partial class Marcas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                List<Articulo> lista = (List<Articulo>)Session["listaArticulo"];
                int id = int.Parse(Request.QueryString["id"].ToString());
                List<Articulo> listaMarca = lista.FindAll(x => x.Marca.IdMarca == id);
                Session.Add("listaProdMarca", listaMarca);
            }
        }
    }
}