using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Acceso BD
using System.Data;
using System.Data.SqlClient;
//Referencia
using Magm.Productos.BE;

namespace Magm.Productos.DataAccess
{
    public class ProductoDataAccess
    {
        //M{etodo Listar
        public List<Producto> ListaProd()
        {
            List<Producto> Lista = new List<Producto>();
            Producto oProducto;
           SqlConnection conec  = new SqlConnection(Helper.conexion());
           SqlCommand    cmd    = new SqlCommand("Select * from Producto", conec);
           conec.Open();
           SqlDataReader dr = cmd.ExecuteReader();

           while (dr.Read())
           {
               oProducto = new Producto();
               oProducto.codigo     = Convert.ToInt32(dr["codigo"]);
               oProducto.nombre     = Convert.ToString(dr["nombre"]);
               oProducto.stock      = Convert.ToInt32(dr["stock"]);
               oProducto.marca      = Convert.ToString(dr["marca"]);
               oProducto.precio     = Convert.ToDecimal(dr["precio"]);
               Lista.Add(oProducto);
           }
            return Lista;
        }

        public int InsertarProd(Producto oProducto)
        {
            int resultado;
            SqlConnection conec = new SqlConnection (Helper.conexion());
            SqlCommand cmd = new SqlCommand("INSERT INTO Producto (codigo, nombre, stock, marca, precio) VALUES (@codigo, @nombre, @stock, @marca, @precio)", conec);

            cmd.Parameters.AddWithValue("@codigo", oProducto.codigo);
            cmd.Parameters.AddWithValue("@nombre", oProducto.nombre);
            cmd.Parameters.AddWithValue("@stock" , oProducto.stock);
            cmd.Parameters.AddWithValue("@marca" , oProducto.marca);
            cmd.Parameters.AddWithValue("@precio", oProducto.precio);
            conec.Open();
            resultado = cmd.ExecuteNonQuery();
            return resultado;
        }

        public int ActualizarProd(Producto oProducto)
        {
            int resultado;
            SqlConnection conec = new SqlConnection (Helper.conexion());
            SqlCommand cmd = new SqlCommand("UPDATE Producto SET nombre=@nombre, stock=@stock, marca=@marca, precio=@precio where codigo=@codigo", conec);
            cmd.Parameters.AddWithValue("@codigo", oProducto.codigo);
            cmd.Parameters.AddWithValue("@nombre", oProducto.nombre);
            cmd.Parameters.AddWithValue("@stock",  oProducto.stock);
            cmd.Parameters.AddWithValue("@marca",  oProducto.marca);
            cmd.Parameters.AddWithValue("@precio", oProducto.precio);

            conec.Open();
            resultado = cmd.ExecuteNonQuery();
            return resultado;
        }

        public Producto SeleccionarProd(int Id)
        {
            Producto  oProducto = new Producto();
            SqlConnection conec = new SqlConnection(Helper.conexion());
            SqlCommand      cmd = new SqlCommand("SELECT * FROM Producto WHERE codigo= '" + Id + "'", conec);
            conec.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            { 
                oProducto.codigo = Convert.ToInt32(dr["codigo"]);
                oProducto.nombre = Convert.ToString(dr["nombre"]);
                oProducto.stock  = Convert.ToInt32(dr["stock"]);
                oProducto.marca  = Convert.ToString(dr["marca"]);
                oProducto.precio = Convert.ToDecimal(dr["precio"]);
            }
            return oProducto;
        }

        public int EliminarProd(int Id)
        {
            int resultado;
            SqlConnection conec = new SqlConnection(Helper.conexion());
            SqlCommand cmd = new SqlCommand("DELETE Producto WHERE codigo ='" + Id + "'", conec);
            conec.Open();
            resultado = cmd.ExecuteNonQuery();
            return resultado;
        }

    }
}
