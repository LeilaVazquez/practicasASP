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
    public partial class FormularioArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            try
            {

                if (!IsPostBack)
                {
                    CategoriaMetodos categoria= new CategoriaMetodos();
                    List<Categoria> lista = categoria.listar(); //voy a crear una lista con las categorias 
                    // los ddl son clave valor

                    ddlCategoria.DataSource = lista;
                    ddlCategoria.DataValueField = "Id"; // clave
                    ddlCategoria.DataTextField = "Descrip"; //valor 
                    ddlCategoria.DataBind();

                    MarcaMetodos marca = new MarcaMetodos();
                    List <Marca> lista2 = marca.listar();

                    ddlMarca.DataSource = lista2;
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataTextField = "Descrip";
                    ddlMarca.DataBind();

                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
                throw;
            }

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Articulos nuevo = new Articulos();
                ArticuloMetodos articulo = new ArticuloMetodos();

                nuevo.Codigo = txtCodigo.Text;
                nuevo.Nombre = txtNombre.Text;
                nuevo.Precio = int.Parse(txtPrecio.Text);
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.ImagenUrl = txtImagenUrl.Text;

                nuevo.Marca = new Marca();
                nuevo.Marca.Id = int.Parse(ddlMarca.SelectedValue);

                nuevo.Categoria = new Categoria();
                nuevo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);

                articulo.agregarConSP(nuevo);
                Response.Redirect("PokemonsLista.aspx", false);

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }

        protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
        {
            imgArticulo.ImageUrl = txtImagenUrl.Text;
        }
    }
}