using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using metodos;

namespace PracticasASP
{
    public partial class PokemonsLista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloMetodos articulo = new ArticuloMetodos();
            dgvArticulos.DataSource = articulo.listarConSP();
            dgvArticulos.DataBind();

        }
    }
}