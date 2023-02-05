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
            try
            {
                if (!IsPostBack)
                {
                    if (Seguridad.sessionActiva(Session["sesionActiva"]))
                    {
                        Usuario2 usuario2 = (Usuario2)Session["sesionActiva"];
                        txtEmail.Text = usuario2.Email;
                        txtEmail.ReadOnly = true;
                        txtNombre.Text = usuario2.Nombre;
                        txtApellido.Text = usuario2.Apellido;
                        txtFechaNacimiento.Text = usuario2.FechaNacimiento.ToString("yyyy-MM-dd"); //le paso el formato q espera la caja de texto 'date'
                        if (!string.IsNullOrEmpty(usuario2.ImagenPerfil))
                            imgNuevoPerfil.ImageUrl = "~/ProfileImages/" + usuario2.ImagenPerfil;
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                    return;

                Usuario2Metodos metodos = new Usuario2Metodos();//hay q tener en cuenta que una cosa es guardar la imagen y otra es levantar la imagen para el login (2 rutas diferentes)
                Usuario2 user = (Usuario2)Session["sesionActiva"];

                //escribir IMG si se cargo algo
                if (txtImagen.PostedFile.FileName != "")
                {
                    string ruta = Server.MapPath("./ProfileImages/");//devuelve la ruta fisica de donde estoy ejecutando
                    txtImagen.PostedFile.SaveAs(ruta + "perfil-" + user.Id + ".jpg"); // PostedFile = obitenen los datos del archivo q se subio
                    user.ImagenPerfil = "perfil-" + user.Id + ".jpg"; //se puede guardar con dateTime.Now 
                }
                user.Nombre = txtNombre.Text;
                user.Apellido = txtApellido.Text;
                user.FechaNacimiento = DateTime.Parse(txtFechaNacimiento.Text);

                metodos.actualizar(user);

                //Leer IMG
                Image img = (Image)Master.FindControl("imgPerfil");
                img.ImageUrl = "~/ProfileImages/" + user.ImagenPerfil; // es como escribir la url del elemento

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                // Response.Redirect("Error.aspx")
            }
        }
    }
}