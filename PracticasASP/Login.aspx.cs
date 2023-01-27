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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /*protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Usuario usuario;
            UsuarioMetodos metodos = new UsuarioMetodos();
            try
            {
                usuario = new Usuario(txtUser.Text, txtPassword.Text, false);
                if (metodos.Loguear(usuario))
                {
                    Session.Add("usuario", usuario); 
                    Response.Redirect("MenuLogin.aspx", false);
                }
                else
                {
                    Session.Add("error", "user o pass incorrectos");
                    Response.Redirect("Error.aspx", false);
                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }

        }*/

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Usuario2 usuario2 = new Usuario2();
            Usuario2Metodos metodos2 = new Usuario2Metodos();
            try
            {
                usuario2.Email = txtEmail.Text;
                usuario2.Pass = txtPassword.Text;

                if (metodos2.Login(usuario2))
                {
                    //Session.Add("", usuario2);
                    //Response.Redirect("MenuLogin.aspx", false); minuto 11 
                }
                else
                {
                    //Session.Add("error", "user o pass incorrectos");
                    //Response.Redirect("Error.aspx", false);
                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}