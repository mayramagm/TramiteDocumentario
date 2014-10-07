using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Refrencia
using System.Configuration;

namespace Magm.Productos.DataAccess
{
    class Helper
    {
        public static string conexion()
        {
            return ConfigurationManager.ConnectionStrings["cnx"].ConnectionString;
        }
    }
}
