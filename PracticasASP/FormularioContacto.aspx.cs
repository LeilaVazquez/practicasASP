using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using metodos;

namespace PracticasASP
{
    public partial class FormularioContacto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            EmailServices emailServices = new EmailServices();

            try
            {
                emailServices.armarCorreo(txtEmail.Text, txtAsunto.Text, txtMensaje.Text); ///validar @ mail
                emailServices.enviarEmail();
                Response.Redirect("EmailOk.aspx");

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }

        }
    }
}