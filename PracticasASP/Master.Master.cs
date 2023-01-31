using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using metodos;
using dominio;

namespace PracticasASP
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e) //exeptuar registrarse y HOME
        {
            if (!(Page is Login || Page is Registro || Page is Default || Page is MenuLogin))
            {
                if (!(Seguridad.sessionActiva(Session["sesionActiva"])))
                    Response.Redirect("Login.aspx", false);
            }
        }
        protected void btnSalir_Click1(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}