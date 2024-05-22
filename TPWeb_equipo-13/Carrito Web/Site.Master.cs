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
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["listaArticulo"] == null)
            {
                gestionArticulo gestionArt = new gestionArticulo();
                List<Articulo> lista = gestionArt.listar();
                Session.Add("listaArticulo", lista);
            }

            if (Session["listaCategoria"] == null)
            {
                gestionCategoria gestionCat = new gestionCategoria();
                List<Categoria> listaCat = gestionCat.listar();
                Session.Add("listaCategoria", listaCat);
            }

            repDDL.DataSource = Session["listaCategoria"];
            repDDL.DataBind();

            if(Session["listaCarrito"] != null) {
            List<Articulo> listaCar = (List<Articulo>)Session["listaCarrito"];
            int carrito = listaCar.Count();
            Session.Add("itemCarrito", carrito);
            }
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string filtro = tbxBuscador.Text;
            Session.Add("busqueda", filtro);
            Response.Redirect("Busqueda.aspx");
        }
    }
}