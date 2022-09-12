using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using INVENTARIO.BL.BE;
using INVENTARIO.BL.BC;

namespace PRESENTACION.Controllers
{
    public class CategoriaController : Controller
    {
        //
        // GET: /Categoria/
        CategoriaBC categoriaBC = new CategoriaBC();
        public ActionResult ListadoCategorias()
        {
            return View(categoriaBC.ListaCategoria());
        }
        public ActionResult InsertarCategoria()
        {
            return View();
        }
        public ActionResult AgregarCategoria(string txtCategoria, string txtDescripcion)
        {
            CategoriaBE categoriaBE = new CategoriaBE();
            categoriaBE.categoria = txtCategoria;
            categoriaBE.descripcion = txtDescripcion;

            string mensaje = "";
            if (categoriaBC.AgregarCategoria(categoriaBE) == true)
            {
                mensaje = "<script language='javascript' type='text/javascript'>" +
                                        "window.location.href=" +
                                        "'/Categoria/ListadoCategorias';</script>";
            }
            else
            {
                mensaje = "<script language='javascript' type='text/javascript'>" +
                                                      "alert('ERROR!!!...CATEGORIA NO AGREGADA');window.location.href=" +
                                                      "'/Categoria/InsertarCategoria';</script>";
            }
            return Content(mensaje);
        }
	}
}