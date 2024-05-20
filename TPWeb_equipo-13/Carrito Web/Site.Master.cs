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
        }
   /*     protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text;
            Session.Add("busqueda", filtro);
        }*/
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text;
            Session.Add("busqueda", filtro);
            Response.Redirect("Busqueda.aspx");
        }
    }
}