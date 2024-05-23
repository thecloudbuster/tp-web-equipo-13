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
                List<Articulo> listaArt = gestionArt.listar();
                Session.Add("listaArticulo", listaArt);
            }

            if (Session["listaCategoria"] == null)
            {
                gestionCategoria gestionCat = new gestionCategoria();
                List<Categoria> listaCat = gestionCat.listar();
                Session.Add("listaCategoria", listaCat);
            }
            repCat.DataSource = Session["listaCategoria"];
            repCat.DataBind();

            if (Session["listaMarca"] == null)
            {
                gestionMarca gestionMarca = new gestionMarca();
                List<Marca> listaMarca = gestionMarca.listar();
                Session.Add("listaMarca", listaMarca);
            }
            repMarca.DataSource = Session["listaMarca"];
            repMarca.DataBind();

        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string filtro = tbxBuscador.Text;
            Session.Add("busqueda", filtro);
            Response.Redirect("Busqueda.aspx", false);
        }
    }
}