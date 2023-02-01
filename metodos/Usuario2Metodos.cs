using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using metodos;

namespace metodos
{
    public class Usuario2Metodos
    {
        //metodo que genere el obj usuario en la DB con solo 2 valores, por defecto ponerlos en 
        //id - email - pass  admin:false

        //nombre apellido fecha imagen

        public int insertarNuevo2(Usuario2 nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("insertarNuevo2");
                datos.setearParametro("@email", nuevo.Email);
                datos.setearParametro("@pass", nuevo.Pass);
                return datos.ejecutarAccionScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public bool Login(Usuario2 usuario2)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Select Id, Email, Pass, Admin, ImagenPerfil, Nombre, Apellido, FechaNacimiento from Usuarios2 where Email = @email and Pass = @pass"); // no deberia haber dos users con el mismo mail, esto tiene q devolver un solo registro
                datos.setearParametro("@email", usuario2.Email);
                datos.setearParametro("@pass", usuario2.Pass);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    usuario2.Id = (int)datos.Lector["Id"];
                    usuario2.Admin = (bool)datos.Lector["Admin"];
                    if (!(datos.Lector["ImagenPerfil"] is DBNull))
                        usuario2.ImagenPerfil = (string)datos.Lector["ImagenPerfil"];
                    if (!(datos.Lector["Nombre"] is DBNull))
                        usuario2.Nombre = (string)datos.Lector["Nombre"];
                    if (!(datos.Lector["Apellido"] is DBNull))
                        usuario2.Apellido = (string)datos.Lector["Apellido"];
                    if (!(datos.Lector["FechaNacimiento"] is DBNull))
                        usuario2.FechaNacimiento = DateTime.Parse(datos.Lector["FechaNacimiento"].ToString()); //1ro a string y desp a DateTime
                   return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void actualizar(Usuario2 user)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Update Usuarios2 set ImagenPerfil = @ImagenPerfil, Nombre = @nombre, Apellido = @apellido, FechaNacimiento = @fecha where Id = @id");
               // datos.setearParametro("@ImagenPerfil", user.ImagenPerfil != null ? user.ImagenPerfil : (object)DBNull.Value);
                datos.setearParametro("@ImagenPerfil", (object)user.ImagenPerfil ?? DBNull.Value); //null coalescing operator
                datos.setearParametro("@nombre", user.Nombre);
                datos.setearParametro("@apellido", user.Apellido);
                datos.setearParametro("@fecha", user.FechaNacimiento);
                datos.setearParametro("@id", user.Id); 
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
