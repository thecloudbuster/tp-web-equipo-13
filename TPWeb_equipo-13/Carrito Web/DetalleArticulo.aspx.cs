using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using gestor;



namespace Carrito_Web
{
    public partial class DetalleArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                int id = int.Parse(Request.QueryString["id"].ToString());
                List<Articulo> temp = (List<Articulo>)Session["listaArticulo"];
                Articulo art = temp.Find(x => x.Id == id);
                lblNombre.Text = art.Nombre;
                lblDesc.Text = art.Descripcion;
                lblPrecio.Text = art.Precio.ToString();
                if (art.imagenes != null)
                {
                    Session.Add("listaImagenes", art.imagenes);
                }
                else
                {
                    List<string> lista = new List<string>();
                    string defaultImageUrl = "https://www.shutterstock.com/image-vector/image-icon-600nw-211642900.jpg";
                    lista.Add(defaultImageUrl);
                    Session.Add("listaImagenes", lista);
                }
            }
        }

    }
}