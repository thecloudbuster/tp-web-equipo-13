using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using gestor;

namespace Carrito_Web
{
    public partial class Productos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                List<Articulo> lista = (List<Articulo>)Session["listaArticulo"];
                int id = int.Parse(Request.QueryString["id"].ToString());
                List<Articulo> listaProducto = lista.FindAll(x => x.Categoria.IdCategoria == id);
                Session.Add("listaProdCategoria", listaProducto);
            }

            if (!IsPostBack)
            {
                repProdCategoria.DataSource = Session["listaProdCategoria"];
                repProdCategoria.DataBind();
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            string id = ((Button)sender).CommandArgument;
            List<Articulo> temp = (List<Articulo>)Session["listaArticulo"];
            Articulo art = temp.Find(x => x.Id.ToString() == id);
            gestionItem gestionIt = new gestionItem();
            itemCarrito item = gestionIt.copiarArticulo(art, 1); //desarrollar el tema de la cantidad
            List<itemCarrito> lista = new List<itemCarrito>();
            if (Session["listaCarrito"] != null)
            {
                lista = (List<itemCarrito>)Session["listaCarrito"];
            }
            lista.Add(item);
            Session.Add("listaCarrito", lista);
            Response.Redirect("Carrito.aspx", false);
        }
    }
}