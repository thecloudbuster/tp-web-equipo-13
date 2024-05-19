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
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Articulo> lista;
            if (Session["listaArticulo"] != null)
            {
                lista = (List<Articulo>)Session["listaArticulo"];
            }
            else
            {
                gestionArticulo gestionArt = new gestionArticulo();
                lista = gestionArt.listar();
                Session.Add("listaArticulo", lista);
            }
        }
    }
}