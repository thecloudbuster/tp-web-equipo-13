using dominio;
using gestor;
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

            if (!IsPostBack)
            {
                repProdMarca.DataSource = Session["listaProdMarca"];
                repProdMarca.DataBind();
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            string id = ((Button)sender).CommandArgument;
            List<Articulo> temp = (List<Articulo>)Session["listaArticulo"];
            Articulo art = temp.Find(x => x.Id.ToString() == id);
            gestionItem gestionIt = new gestionItem();
            itemCarrito item = gestionIt.copiarArticulo(art, 1);
            List<itemCarrito> lista = new List<itemCarrito>();
            if (Session["listaCarrito"] != null)
            {
                lista = (List<itemCarrito>)Session["listaCarrito"];
                itemCarrito itemGuardado = lista.Find(x => x.Id.ToString() == id);
                if (itemGuardado != null)
                {
                    item.Cantidad += itemGuardado.Cantidad;
                    lista.Remove(itemGuardado);
                }
            }
            lista.Add(item);
            Session.Add("listaCarrito", lista);
            Response.Redirect("Carrito.aspx", false);
        }
    }
}