using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using metodos;

namespace PracticasASP
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario2 user = new Usuario2();
                Usuario2Metodos usuario2 = new Usuario2Metodos();
                EmailServices emailService = new EmailServices();

                user.Email = txtEmail.Text;
                user.Pass = txtPassword.Text;
                int id = usuario2.insertarNuevo2(user);

                emailService.armarCorreo(user.Email, "Bienvenido", "Hola, estas registrado");
                emailService.enviarEmail();
                Response.Redirect("EmailOk.aspx", false); //false para que no cancele la ejecucion

                
            }
            catch (Exception ex) 
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx",false);  
            }
        }
    }
}