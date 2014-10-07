using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Magm.Productos.BE
{
    public class Producto
    {
        public int      codigo  { get; set; }
        public string   nombre  { get; set; }
        public int      stock   { get; set; }
        public string   marca   { get; set; }
        public decimal  precio  { get; set; }
    }
}
