using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using INVENTARIO.BL.BE;
using INVENTARIO.BL.BC;

namespace WepAppMVC.Controllers
{
    public class UnidadDeMedidaController : Controller
    {
        //
        // GET: /UnidadDeMedida/
        UnidadDeMedidaBC unidadDeMedidaBC = new UnidadDeMedidaBC();
        public ActionResult ListadoUnidadDeMedidas()
        {
            return View(unidadDeMedidaBC.ListarUnidadDeMedida());
        }
        public ActionResult InsertarUnidadDeMedida()
        {
            return View();
        }

        public ActionResult AgregarUnidadDeMedida(string txtDescripcion, string txtSimbolo)
        {
            string mensaje = "";
            UnidadDeMedidaBE unidadDeMedidaBE = new UnidadDeMedidaBE();
            unidadDeMedidaBE.descripcion = txtDescripcion;
            unidadDeMedidaBE.simbolo = txtSimbolo;

            if (unidadDeMedidaBC.AgregarUnidadDeMedida(unidadDeMedidaBE) == true)
            {
                mensaje = "<script language='javascript' type='text/javascript'>" +
                                                      "alert('UNIDAD DE MEDIDA AGREGADA');window.location.href=" +
                                                      "'/UnidadDeMedida/ListadoUnidadDeMedidas';</script>";
            }
            else
            {
                mensaje = "<script language='javascript' type='text/javascript'>" +
                                                      "alert('ERROR!!!...UNIDAD NO AGREGADA');window.location.href=" +
                                                      "'/UnidadDeMedida/InsertarUnidadDeMedida';</script>";
            }

            return Content(mensaje);
        }
	}
}