using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using INVENTARIO.BL.BE;
using INVENTARIO.BL.BC;

namespace PRESENTACION.Controllers
{
    public class EstadoController : Controller
    {
        //
        // GET: /Estado/
        EstadoBC estadoBC = new EstadoBC();
        public ActionResult ListadoEstados()
        {
            return View(estadoBC.ListarEstado());
        }
        public ActionResult InsertarEstado()
        {
            return View();
        }
        public ActionResult AgregarEstado(string txtDescripcion)
        {
            EstadoBE estadoBE = new EstadoBE();
            estadoBE.descripcion = txtDescripcion;

            string mensaje = "";
            if (estadoBC.AgregarEstado(estadoBE) == true)
            {
                mensaje = "<script language='javascript' type='text/javascript'>" +
                                                      "window.location.href=" +
                                                      "'/Estado/ListadoEstados';</script>";
            }
            else
            {
                mensaje = "<script language='javascript' type='text/javascript'>" +
                                                      "alert('ERROR!!!...ESTADO NO AGREGADO');window.location.href=" +
                                                      "'/Estado/InsertarEstado';</script>";
            }
            return Content(mensaje);
        }
	}
}