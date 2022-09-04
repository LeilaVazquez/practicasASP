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
    public partial class Default : System.Web.UI.Page
    {
        public List<Articulos> ListaArticulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloMetodos articulo = new ArticuloMetodos();
            ListaArticulos = articulo.listarConSP();

            if (!IsPostBack)
            {
                Repeater1.DataSource = ListaArticulos;
                Repeater1.DataBind();
            }
        }
        protected void btnEjemplo_Click(object sender, EventArgs e)
        {
            string valor = ((Button)sender).CommandArgument;
            //Casteo explicito para transformarlo en boton y capturar el id
        }
    }
}