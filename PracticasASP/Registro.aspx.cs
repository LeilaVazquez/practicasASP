using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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

            }
            catch (Exception ex) 
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx",false);  
            }
        }
    }
}