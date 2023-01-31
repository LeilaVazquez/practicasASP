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
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try 
            {
                //hay q tener en cuenta que una cosa es guardar la imagen y otra es levantar la imagen para el login (2 rutas diferentes)
                string ruta = Server.MapPath("./ProfileImages/");//devuelve la ruta fisica de donde estoy ejecutando
                Usuario2 user = (Usuario2)Session["sesionActiva"]; //
                txtImagen.PostedFile.SaveAs(ruta + "perfil-" + user.Id + ".jpg"); // PostedFile = obitenen los datos del archivo q se subio
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
               // Response.Redirect("Error.aspx")
            }
        }
    }
}