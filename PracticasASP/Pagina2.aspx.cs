using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PracticasASP
{
    public partial class Pagina2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Session["usuario"] != null && ((dominio.Usuario)Session["usuario"]).TipoUsuario == dominio.TipoUsuario.ADMIN))
            {
                Session.Add("error", "No tienes permisos para ingresar. Necesitas nivel admin.");
                Response.Redirect("Error.aspx", false);
            }
        }
        protected void btnRegresar2_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuLogin.aspx");
        }
    }
}