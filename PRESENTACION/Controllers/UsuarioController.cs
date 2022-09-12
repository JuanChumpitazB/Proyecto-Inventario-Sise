using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using INVENTARIO.BL.BE;
using INVENTARIO.BL.BC;

namespace PRESENTACION.Controllers
{
    public class UsuarioController : Controller
    {
        //
        // GET: /Usuario/
        UsuarioBC usuarioBC = new UsuarioBC();
        public ActionResult Inicio()
        {
            return View();
        }

        public JsonResult Logear(string usuario, string password)
        {
            string mensaje = "";
            bool link = false;
            bool indicador = false;

            if (usuarioBC.ExisteUsuario(usuario) == true)
            {
                if (usuarioBC.VerificarEstado(usuario) == 1)
                {
                    if (usuarioBC.ValidarLogin(usuario, password) == true)
                    {
                        if (usuarioBC.VerificarPasswordNuevo(usuario).Equals("123456"))
                        {
                            usuarioBC.ActualizarIntenosCero(usuario);
                            mensaje = "/Usuario/NuevoPassword";
                            indicador = true;
                            link = true;
                        }
                        else
                        {
                            usuarioBC.ActualizarIntenosCero(usuario);

                            if (usuarioBC.VerificarRol(usuario) == 1)
                            {
                                mensaje = "/Usuario/ListadoUsuarios";
                                link = true;
                                indicador = true;
                            }
                            else
                            {
                                mensaje = "/Producto/ListarProductos";
                                link = true;
                                indicador = true;
                            }
                        }

                    }
                    else
                    {
                        usuarioBC.ActualizarIntenosSumar(usuario);
                        mensaje = "PASSWORD INCORRECTO";
                        if (usuarioBC.VerificarIntentos(usuario) >= 3)
                        {
                            usuarioBC.ActualizarEstado(usuario, 0);
                        }
                    }
                }
                else
                {
                    mensaje = "ESTADO DE USUARIO BLOQUEADO! CONSULTE CON SU ADMINISTRADOR";
                }
            }
            else
            {
                mensaje = "USUARIO NO ENCONTRADO";
            }
            List<string> lst = new List<string>();
            lst.Add(indicador.ToString());
            lst.Add(link.ToString());
            lst.Add(mensaje);

            return Json(lst, JsonRequestBehavior.AllowGet);
        }


        public ActionResult ListadoUsuarios()
        {
            return View(usuarioBC.ListaUsuarios());
        }
        public ActionResult ListadoUsuariosBloqueados()
        {
            return View(usuarioBC.ListaUsuariosBloqueados());
        }
        public ActionResult EditarEstado(int idUsuario)
        {
           

            return View(usuarioBC.BuscarXid(idUsuario));
        }
        public ActionResult ActualizarEstado(string txtUsuario, byte txtEstado)
        {
            string mensaje = "";
            usuarioBC.ActualizarIntenosCero(txtUsuario);
            if (usuarioBC.ActualizarEstado(txtUsuario, txtEstado) == true)
            {
                mensaje = "<script language='javascript' type='text/javascript'>" +
                                                            "alert('ESTADO DE USUARIO ACTUALIZADO!');window.location.href=" +
                                                             "'/Usuario/ListadoUsuarios';</script>";
            }
            else
            {
                mensaje = "<script language='javascript' type='text/javascript'>" +
                                             "alert('ERROR! NO SE PUDO CAMBIAR EL ESTADO');window.location.href=" +
                                              "'/Usuario/ListadoUsuarios';</script>";
            }

            return Content(mensaje);
        }
        public ActionResult InsertarUsuario()
        {
            RolBC rolBC = new RolBC();
            List<RolBE> listaUsu = new List<RolBE>();
            listaUsu = rolBC.ListarRol();
            ViewBag.ListaRol = listaUsu;

            return View();
        }
        public ActionResult AgregarUsuario(string txtNombres, string txtApellidoPaterno, string txtApellidoMaterno, string txtDNI,
                                            string txtTelefono, string txtDireccion, string txtUsuario, int cboRol)
        {
            string mensaje = "";

            UsuarioBE usuarioBE = new UsuarioBE();
            usuarioBE.nombres = txtNombres;
            usuarioBE.apellidoPaterno = txtApellidoPaterno;
            usuarioBE.apellidoMaterno = txtApellidoMaterno;
            usuarioBE.dni = txtDNI;
            usuarioBE.telefono = txtTelefono;
            usuarioBE.direccion = txtDireccion;
            usuarioBE.ususario = txtUsuario;
            usuarioBE.rolBE.idRol = cboRol;

            if (usuarioBC.AgregarUsuario(usuarioBE) == true)
            {
                mensaje = "<script language='javascript' type='text/javascript'>" +
                                                       "window.location.href=" +
                                                       "'/Usuario/ListadoUsuarios';</script>";
            }
            else
            {
                mensaje = "<script language='javascript' type='text/javascript'>" +
                                        "alert('USUARIO NO ENCONTRADO');window.location.href=" +
                                        "'/Usuario/InsertarUsuario';</script>";
            }

            return Content(mensaje);
        }


        public ActionResult EditarUsuario(int idUsuario)
        {
            RolBC rolBC = new RolBC();
            List<RolBE> listaUsu = new List<RolBE>();
            listaUsu = rolBC.ListarRol();
            ViewBag.ListaRol = listaUsu;

            return View(usuarioBC.BuscarXid(idUsuario));
        }


        public ActionResult ActualizarUsuario(int txtIDUsuario, string txtNombres, string txtApellidoPaterno, string txtApellidoMaterno, string txtDNI,
                                            string txtTelefono, string txtDireccion, string txtUsuario, byte txEstado, int cboRol)
        {
            string mensaje = "";

            UsuarioBE usuarioBE = new UsuarioBE();
            usuarioBE.idUsuario = txtIDUsuario;
            usuarioBE.nombres = txtNombres;
            usuarioBE.apellidoPaterno = txtApellidoPaterno;
            usuarioBE.apellidoMaterno = txtApellidoMaterno;
            usuarioBE.dni = txtDNI;
            usuarioBE.telefono = txtTelefono;
            usuarioBE.direccion = txtDireccion;
            usuarioBE.ususario = txtUsuario;
            usuarioBE.estado = txEstado;
            usuarioBE.rolBE.idRol = cboRol;

            if (usuarioBC.ActualizarUsuario(usuarioBE) == true)
            {
                mensaje = "<script language='javascript' type='text/javascript'>" +
                                                       "alert('USUARIO ACTUALIZADO');window.location.href=" +
                                                       "'/Usuario/ListadoUsuarios';</script>";
            }
            else
            {
                mensaje = "<script language='javascript' type='text/javascript'>" +
                                        "alert('USUARIO NO ACTUALIZADO');window.location.href=" +
                                        "'/Usuario/EditarUsuario';</script>";
            }

            return Content(mensaje);
        }

        public ActionResult EliminarUsuario(int idUsuario)
        {
            string mensaje = "";

            if (usuarioBC.Eliminar(idUsuario) == true)
            {
                mensaje = "<script language='javascript' type='text/javascript'>" +
                                       "alert('USUARIO ELIMINADO!');window.location.href=" +
                                       "'/Usuario/ListadoUsuarios';</script>";
            }
            else
            {
                mensaje = "<script language='javascript' type='text/javascript'>" +
                                                      "alert('ERROR!!!...NO SE PUDO ELIMINAR EL USUARIO');window.location.href=" +
                                                      "'/Producto/ListadoUsuarios';</script>";
            }

            return Content(mensaje);
        }


        public ActionResult NuevoPassword()
        {
            return View();
        }
        public ActionResult ActualizarPassword(string txtUsuario, string txtPassword, string txtPasswordNuevo, string txtPasswordNuevoConfirmar)
        {
            string mensaje = "";

            if (usuarioBC.ExisteUsuario(txtUsuario) == true)
            {
                if (usuarioBC.ValidarLogin(txtUsuario,txtPassword)==true)
                {
                    if (txtPasswordNuevo.Equals(txtPasswordNuevoConfirmar))
                    {
                        if (usuarioBC.NuevoPassword(txtUsuario, txtPassword, txtPasswordNuevo)==true)
                        {
                            mensaje = "<script language='javascript' type='text/javascript'>" +
                                                                  "alert('PASSWORD ACTUALIZADO');window.location.href=" +
                                                                  "'/Usuario/Inicio';</script>";
                        }
                        else
                        {
                            mensaje = "<script language='javascript' type='text/javascript'>" +
                                       "alert('ERROR! NO SE ACTUALIZO EL PASSWORD');window.location.href=" +
                                       "'/Usuario/NuevoPassword';</script>";
                        }
                    }
                    else
                    {
                        mensaje = "<script language='javascript' type='text/javascript'>" +
                                   "alert('PASSWORD NUEVO DEBE SER IGUAL A LA CONFIRMACION');window.location.href=" +
                                   "'/Usuario/NuevoPassword';</script>";
                    }
                }
                else
                {
                    mensaje = "<script language='javascript' type='text/javascript'>" +
                               "alert('PASSWORD ANTERIOR NO VALIDO');window.location.href=" +
                               "'/Usuario/NuevoPassword';</script>";
                }
            }
            else
            {
                mensaje = "<script language='javascript' type='text/javascript'>" +
                           "alert('USUARIO NO ENCONTRADO');window.location.href=" +
                           "'/Usuario/NuevoPassword';</script>";
            }

            return Content(mensaje);
        }

        public ActionResult ReestablecerPassword()
        {
            return View(usuarioBC.ListaUsuarios());
        }
        public ActionResult ReestablecerPasswordEjecutar(int idUsuario)
        {
            string mensaje = "";
            UsuarioBE usuarioBE = usuarioBC.BuscarXid(idUsuario);

            if (usuarioBC.ReestablecerPassword(idUsuario) == true)
            {
                usuarioBC.ActualizarIntenosCero(usuarioBE.ususario);
                usuarioBC.ActualizarEstado(usuarioBE.ususario,1);
                mensaje = "<script language='javascript' type='text/javascript'>" +
                           "alert('PASSWORD REESTABLECIDO');window.location.href=" +
                           "'/Usuario/ListadoUsuarios';</script>";
            }
            

            return Content(mensaje);
        }

	}
}