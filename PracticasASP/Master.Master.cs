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
        protected void Page_Load(object sender, EventArgs e) //ver Avatar en Default con sesionActiva
        {
            imgPerfil.ImageUrl = "https://app.cdnstabletransit.net/images/avatar-whiteback.png"; 
            if (!(Page is Login || Page is Registro || Page is Default || Page is MenuLogin || Page is Error)) //page MenuLogin inhabilitada xq Login lee DB Usuario2!!
            {
                if (!(Seguridad.sessionActiva(Session["sesionActiva"])))
                {
                    Response.Redirect("Login.aspx", false);
                }
                else
                {
                    Usuario2 user = (Usuario2)Session["sesionActiva"];
                    lblUser.Text = user.Email;
                    if (!string.IsNullOrEmpty(user.ImagenPerfil))
                        imgPerfil.ImageUrl = "~/ProfileImages/" + user.ImagenPerfil;
                }
            }
        }
        protected void btnSalir_Click1(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}