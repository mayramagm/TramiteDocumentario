using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//Agregando Referencia
using Magm.Productos.BE;
using Magm.Productos.BusinessLogic;

namespace Magm.Productos.MVC.Controllers
{
    public class ProductoController : Controller
    {
        //
        // GET: /Producto/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListarProducto()
        {
            List<Producto> Listar;
            ProductoBusinessLogic oProducto = new ProductoBusinessLogic();
            Listar = oProducto.ListarProducto();
            return View(Listar);
        }

        public ActionResult InsertarProducto()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult InsertarProducto(Producto oProd)
        {
            int respuesta;
            ProductoBusinessLogic oProducto = new ProductoBusinessLogic();
            respuesta = oProducto.InsertarProducto(oProd);
            return RedirectToAction("ListarProducto", "Producto");
        }

        public ActionResult ActualizarProducto(int Id)
        {
            Producto clsProducto;
            ProductoBusinessLogic oProducto = new ProductoBusinessLogic();
            clsProducto = oProducto.DetalleProducto(Id);
            return View(clsProducto);
        }

        [HttpPost]
        public ActionResult ActualizarProducto(Producto oProd)
        {
            int respuesta;
            ProductoBusinessLogic oProducto = new ProductoBusinessLogic();
            respuesta = oProducto.ActualizarProducto(oProd);
            return RedirectToAction("ListarProducto", "Producto");
        }

        public ActionResult DetallesProducto(int Id)
        {
            Producto clsProducto;
            ProductoBusinessLogic oProducto = new ProductoBusinessLogic();
            clsProducto = oProducto.DetalleProducto(Id);
            return View(clsProducto);
        }

        public ActionResult EliminarProducto()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EliminarProducto(int Id)
        {
            int Respuesta;
            ProductoBusinessLogic oProducto = new ProductoBusinessLogic();
            Respuesta = oProducto.EliminarProducto(Id);
            return RedirectToAction("ListarProducto", "Producto");
        }
    }
}
