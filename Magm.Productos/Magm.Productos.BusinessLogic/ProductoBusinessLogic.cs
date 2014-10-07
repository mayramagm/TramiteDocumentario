using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Referencias
using Magm.Productos.BE;
using Magm.Productos.DataAccess;

namespace Magm.Productos.BusinessLogic
{
    public class ProductoBusinessLogic
    {
        public List<Producto> ListarProducto()
        {
            List<Producto> Lista;
            ProductoDataAccess oProducto = new ProductoDataAccess();
            Lista = oProducto.ListaProd();
            return Lista;
        }

        public int InsertarProducto(Producto oProd)
        {
            int respuesta;
            ProductoDataAccess oProducto = new ProductoDataAccess();
            respuesta = oProducto.InsertarProd(oProd);
            return respuesta;
        }

         public int ActualizarProducto(Producto oProd)
        {
            int respuesta;
            ProductoDataAccess oProducto = new ProductoDataAccess();
            respuesta = oProducto.ActualizarProd(oProd);
            return respuesta;
        }

         public Producto DetalleProducto(int Id)
         {
             Producto oProd = new Producto();
             ProductoDataAccess oProducto = new ProductoDataAccess();
             oProd = oProducto.SeleccionarProd(Id);
             return oProd;
         }

         public int EliminarProducto(int Id) 
         {
             int respuesta;
             ProductoDataAccess oProducto = new ProductoDataAccess();
             respuesta = oProducto.EliminarProd(Id);
             return respuesta;
         }

    }
}
