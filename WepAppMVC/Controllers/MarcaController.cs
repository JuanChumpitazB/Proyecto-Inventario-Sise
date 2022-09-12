using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using INVENTARIO.BL.BE;
using INVENTARIO.BL.BC;

namespace WepAppMVC.Controllers
{
    public class MarcaController : Controller
    {
        //
        // GET: /Marca/
        MarcaBC marcaBC = new MarcaBC();
        public ActionResult ListadoMarcas()
        {
            return View(marcaBC.ListarMarcas());
        }
        public ActionResult InsertarMarca()
        {
            CategoriaBC categoriaBC = new CategoriaBC();
            List<CategoriaBE> listaCate = new List<CategoriaBE>();
            listaCate = categoriaBC.ListaCategoria();
            ViewBag.ListaCategoria = listaCate;

            return View();
        }
        public ActionResult AgregarMarca(string txtMarca, int cboCategoria)
        {
            string mensaje = "";
            MarcaBE marcaBE = new MarcaBE();
            marcaBE.marca = txtMarca;
            marcaBE.categoriaBE.idCategoria = cboCategoria;

            if (marcaBC.AgregarMarca(marcaBE) == true)
            {
                mensaje = "<script language='javascript' type='text/javascript'>" +
                                                      "alert('MARCA AGREGADA');window.location.href=" +
                                                      "'/Marca/ListadoMarcas';</script>";
            }
            else
            {
                mensaje = "<script language='javascript' type='text/javascript'>" +
                                                         "alert('ERROR!!!...MARCA NO AGREGADA');window.location.href=" +
                                                         "'/Marca/InsertarMarca';</script>";
            }
            return Content(mensaje);
        }
	}
}