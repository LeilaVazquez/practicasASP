using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using metodos;

namespace PracticasASP
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e) //exeptuar registrarse y HOME
        {
            if (!(Page is Login))// ! si page es un objeto del tipo Login -- pregunto la page que esta aca -  lo hago con subtipo
            {
                if (!(Seguridad.sessionActiva(Session["sesionActiva"])))
                {
                    Response.Redirect("Login.aspx", false);
                }
            }


        }
    }
}