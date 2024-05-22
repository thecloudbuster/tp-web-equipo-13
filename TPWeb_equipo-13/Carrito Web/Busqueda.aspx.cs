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
    public partial class Busqueda : System.Web.UI.Page
    {
              protected void Page_Load(object sender, EventArgs e)
               {
                   string filtro;
                   List<Articulo> listafiltrada = new List<Articulo>();
                   List<Articulo> lista = (List<Articulo>)Session["listaArticulo"];
                   if (Session["busqueda"] == null || (string)Session["busqueda"] == "")
                   {
                       Response.Redirect("Default.aspx");
                   }
                   else
                   {
                       filtro = (string)Session["busqueda"];
                       listafiltrada = lista.FindAll(x => x.Nombre.ToLower().Contains(filtro.ToLower()) || x.Marca.ToString().ToLower().Contains(filtro.ToLower()) || x.Descripcion.ToLower().Contains(filtro.ToLower()) || x.Categoria.ToString().ToLower().Contains(filtro.ToLower()));
                       Session.Add("listaBusqueda", listafiltrada);
                   }
               }
        /*protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                string filtro = Request.QueryString["id"];
                List<Articulo> temp = (List<Articulo>)Session["listaArticulo"];
                List<Articulo> listafiltrada = new List<Articulo>();
                listafiltrada = temp.FindAll(x => x.Nombre.ToLower().Contains(filtro.ToLower()) || x.Marca.ToString().ToLower().Contains(filtro.ToLower()) || x.Descripcion.ToLower().Contains(filtro.ToLower()) || x.Categoria.ToString().ToLower().Contains(filtro.ToLower()));
                Session.Add("listaBusqueda", listafiltrada);
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }*/
    }
}
