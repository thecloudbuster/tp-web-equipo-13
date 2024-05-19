using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using conexion;
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
                lblMarca.Text = art.Marca.Descripcion;
                lblCategoria.Text = art.Categoria.Descripcion;
                lblPrecio.Text = art.Precio.ToString();
                string defaultImageUrl = "https://www.shutterstock.com/image-vector/image-icon-600nw-211642900.jpg";
                string imagen = art.imagenes != null && art.imagenes.Count > 0 ? art.imagenes[0] : defaultImageUrl;
                imgArt.ImageUrl = imagen;
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Articulo art = new Articulo();
            if (Request.QueryString["id"] != null)
            {
                int id = int.Parse(Request.QueryString["id"].ToString());
                List<Articulo> temp = (List<Articulo>)Session["listaArticulo"];
                art = temp.Find(x => x.Id == id);
                List<Articulo> lista;
                if (Session["listaCarrito"] != null)
                {
                    lista = (List<Articulo>)Session["listaCarrito"];
                    lista.Add(art);
                }
                else
                {
                    lista = new List<Articulo>();
                    lista.Add(art);
                    Session.Add("listaCarrito", lista);
                }
            }
            Response.Redirect("Default.aspx");
        }
    }
}