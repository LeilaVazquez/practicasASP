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
    public partial class PokemonsLista : System.Web.UI.Page
    {
        public bool FiltroAvanzado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Seguridad.esAdmin(Session["sesionActiva"])))
            {
                Session.Add("error", "Se requieren permisos de administrador para ingresar");
                Response.Redirect("Error.aspx", false);
            }

            FiltroAvanzado = chkAvanzado.Checked;
            if (!IsPostBack)
            {
                FiltroAvanzado = false;
                ArticuloMetodos articulo = new ArticuloMetodos();
                Session.Add("listaArticulos", articulo.listarConSP());
                dgvArticulos.DataSource = Session["listaArticulos"];
                dgvArticulos.DataBind();
            }
        }

        protected void dgvArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvArticulos.PageIndex = e.NewPageIndex;
            dgvArticulos.DataBind();
        }
        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvArticulos.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioArticulo.aspx?id=" + id);
        }

        protected void filtro_TextChanged(object sender, EventArgs e)
        {
            List<Articulos> lista = (List<Articulos>)Session["listaArticulos"];
            List<Articulos> listafiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltro.Text.ToUpper()));
            dgvArticulos.DataSource = listafiltrada;
            dgvArticulos.DataBind();
        }

        protected void chkAvanzado_CheckedChanged(object sender, EventArgs e) //maneja el cambio de estado de la property Filtro Avanzado.
        {
            FiltroAvanzado = chkAvanzado.Checked;
            txtFiltro.Enabled = !FiltroAvanzado;
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCriterio.Items.Clear();//para que no acumule las cosas cargadas
            if(ddlCampo.SelectedItem.ToString() == "Precio")
            {
                ddlCriterio.Items.Add("Mayor a");
                ddlCriterio.Items.Add("Menor a");
                ddlCriterio.Items.Add("Igual a");
            }
            else
            {
                ddlCriterio.Items.Add("Comienza con");
                ddlCriterio.Items.Add("Termina con");
                ddlCriterio.Items.Add("Contiene");
            }
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                ArticuloMetodos metodos = new ArticuloMetodos();
                dgvArticulos.DataSource = metodos.filtrar(ddlCampo.SelectedItem.ToString(), 
                ddlCriterio.SelectedItem.ToString(), 
                txtFiltroAvanzado.Text);
                dgvArticulos.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                throw;
            }
        }
    }
}