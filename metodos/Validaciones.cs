using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace metodos
{
    public static class Validaciones
    {
        public static bool textoVacio(object control)
        {
            if (control is TextBox)
            return true;
        }
    }
}
