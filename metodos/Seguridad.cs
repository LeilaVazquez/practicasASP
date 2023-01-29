using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace metodos
{
    public static class Seguridad //
    {
        public static bool sessionActiva(object user)
        {

            Usuario2 usuario = user != null ? (Usuario2)user : null;
            if (usuario != null && usuario.Id != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool esAdmin(object user) //esta propiedad se escribe cuando te logueas si es 1  o 0 ADMIN o no
        {
            Usuario2 usuario = user != null ? (Usuario2)user : null;
            return usuario != null ? usuario.Admin : false;
        }
    }
}
