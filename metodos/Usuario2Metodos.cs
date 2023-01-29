using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

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
                datos.setearConsulta("Select Id, Email, Pass, Admin from Usuarios2 where Email = @email and Pass = @pass"); // no deberia haber dos users con el mismo mail, esto tiene q devolver un solo registro
                datos.setearParametro("@email", usuario2.Email);
                datos.setearParametro("@pass", usuario2.Pass);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    usuario2.Id = (int)datos.Lector["Id"];
                    usuario2.Admin = (bool)datos.Lector["Admin"];
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
