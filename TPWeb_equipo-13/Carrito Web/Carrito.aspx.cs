using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using gestor;
namespace Carrito_Web
{
    public partial class Carrito : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Articulo> lista;
            if (Session["listaCarrito"] != null)
            {
                lista = (List<Articulo>)Session["listaCarrito"];
            }
            else
            {
                lista = new List<Articulo>();
                Session.Add("listaCarrito", lista);
            }
        }
    }
}