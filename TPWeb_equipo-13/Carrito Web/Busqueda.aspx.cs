using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Carrito_Web
{
    public partial class Busqueda : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["busqueda"] == null || (string)Session["busqueda"] == "")
            {
                Response.Redirect("Default.aspx", false);
            }
            else
            {
                List<Articulo> lista = (List<Articulo>)Session["listaArticulo"];
                string filtro = (string)Session["busqueda"];
                List<Articulo> listafiltrada = lista.FindAll(x => x.Nombre.ToLower().Contains(filtro.ToLower()) || x.Marca.ToString().ToLower().Contains(filtro.ToLower()) || x.Descripcion.ToLower().Contains(filtro.ToLower()) || x.Categoria.ToString().ToLower().Contains(filtro.ToLower()));
                Session.Add("listaBusqueda", listafiltrada);
            }
        }
    }
}
