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
        public bool ConfirmaEliminacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            //Configuracion inicial de la pantalla
            txtId.Enabled = false;
            ConfirmaEliminacion = false;
            try
            {

                if (!IsPostBack)
                {
                    CategoriaMetodos categoria = new CategoriaMetodos();
                    List<Categoria> lista = categoria.listar(); //voy a crear una lista con las categorias 
                    // los ddl son clave valor

                    ddlCategoria.DataSource = lista;
                    ddlCategoria.DataValueField = "Id"; // clave
                    ddlCategoria.DataTextField = "Descrip"; //valor 
                    ddlCategoria.DataBind();

                    MarcaMetodos marca = new MarcaMetodos();
                    List<Marca> lista2 = marca.listar();

                    ddlMarca.DataSource = lista2;
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataTextField = "Descrip";
                    ddlMarca.DataBind();

                }
                //configuracion si estamos modificando
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if (id != "" && !IsPostBack)
                {
                    ArticuloMetodos articulo = new ArticuloMetodos();
                    //List<Articulos> lista = articulo.listar(id);
                    // Articulos seleccionado = lista[0];
                    Articulos seleccionado = (articulo.listar(id))[0];

                    //precargar todos los campos con el articulo seleccionado
                    txtId.Text = id;
                    txtCodigo.Text = seleccionado.Codigo;
                    txtNombre.Text = seleccionado.Nombre;
                    txtDescripcion.Text = seleccionado.Descripcion;
                    txtPrecio.Text = seleccionado.Precio.ToString();
                    txtImagenUrl.Text = seleccionado.ImagenUrl;


                    ddlMarca.SelectedValue = seleccionado.Marca.Id.ToString();
                    ddlCategoria.SelectedValue = seleccionado.Categoria.Id.ToString();
                    txtImagenUrl_TextChanged(sender, e);

                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx",false);
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
                nuevo.Precio = decimal.Parse(txtPrecio.Text);
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.ImagenUrl = txtImagenUrl.Text;

                nuevo.Marca = new Marca();
                nuevo.Marca.Id = int.Parse(ddlMarca.SelectedValue);
                nuevo.Categoria = new Categoria();
                nuevo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);

                if (Request.QueryString["id"] != null)
                {
                    nuevo.Id = int.Parse(txtId.Text);
                    articulo.modificarConSP(nuevo);
                }
                else
                {
                    articulo.agregarConSP(nuevo);
                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }

            Response.Redirect("PokemonsLista.aspx", false);
        }
        protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
        {
            imgArticulo.ImageUrl = txtImagenUrl.Text;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ConfirmaEliminacion = true;
        }
        protected void btnConfirmarEliminacion_Click(object sender, EventArgs e)
        {
            try
            {
                if (ckConfirmaEliminacion.Checked)
                {
                    ArticuloMetodos articulo = new ArticuloMetodos();
                    articulo.eliminarConSP(int.Parse(txtId.Text));
                    Response.Redirect("PokemonsLista.aspx");
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}