using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using INVENTARIO.BL.BE;
using INVENTARIO.BL.BC;

namespace PRESENTACION.Controllers
{
    public class ProductoController : Controller
    {
        //
        // GET: /Producto/
        ProductoBC productoBC = new ProductoBC();
        CategoriaBC categoriaBC = new CategoriaBC();
        MarcaBC marcaBC = new MarcaBC();
        UnidadDeMedidaBC unidadDeMedidaBC = new UnidadDeMedidaBC();
        EstadoBC estadoBC = new EstadoBC();
        FotoBC fotoBC = new FotoBC();
        public ActionResult Inicio()
        {
            return View();
        }
        
        public ActionResult ListarProductos()
        {
            return View(productoBC.ListaProducto());
        }
        public ActionResult ListarProductosOptimo()
        {
            return View(productoBC.ListarProductosOptimo());
        }
        public ActionResult ListarProductosMerma()
        {
            return View(productoBC.ListarProductosMerma());
        }
        public ActionResult ListarProductosXvencer()
        {
            return View(productoBC.ListarProductosXvencer());
        }

        public ActionResult ProductosXagotarse()
        {
            return View(productoBC.ProductosXagotarse());
        }

        public ActionResult InsertarProducto()
        {
            List<CategoriaBE> listaCategoria = new List<CategoriaBE>();
            CategoriaBC categoriaBC = new CategoriaBC();
            listaCategoria = categoriaBC.ListaCategoria();
            ViewBag.ListaCategorias = listaCategoria;

            List<MarcaBE> listaMarca = new List<MarcaBE>();
            MarcaBC marcaBC = new MarcaBC();
            listaMarca = marcaBC.ListarMarcas();
            ViewBag.ListMarcas = listaMarca;

            UnidadDeMedidaBC unidadDeMedidaBC = new UnidadDeMedidaBC();
            List<UnidadDeMedidaBE> listaUnidadDeMedida = new List<UnidadDeMedidaBE>();
            listaUnidadDeMedida = unidadDeMedidaBC.ListarUnidadDeMedida();
            ViewBag.ListaUnidadDeMedida = listaUnidadDeMedida;

            EstadoBC estadoBC = new EstadoBC();
            List<EstadoBE> listaEstado = new List<EstadoBE>();
            listaEstado = estadoBC.ListarEstado();
            ViewBag.ListaEstado = listaEstado;


            FotoBC fotoBC = new FotoBC();
            List<FotoBE> listaFoto = new List<FotoBE>();
            listaFoto = fotoBC.ListarFoto();
            ViewBag.ListaFoto = listaFoto;
            


            return View();
        }
        public ActionResult AgregarProducto(string txtDescripcion, int cboMarca, string txtMedida, int cboUnidadDeMedida, int txtUnidadesEnExistencia, 
                                            DateTime dtFechaVencimiento, int cboEstado, double txtPrecio, string foto)
        {
            string mensaje = "";

            ProductoBE productoBE = new ProductoBE();
            productoBE.descripcion = txtDescripcion;
            productoBE.marcaBE.idMarca = cboMarca;
            productoBE.medida = txtMedida;
            productoBE.unidadDeMedidaBE.idUnidad = cboUnidadDeMedida;
            productoBE.unidadesEnExistencia = txtUnidadesEnExistencia;
            productoBE.fechaVencimiento = dtFechaVencimiento;
            productoBE.estadoBE.idEstado = cboEstado;
            productoBE.precio = txtPrecio;

            int idFoto = fotoBC.ExisteFotoSINOagregar_ObtenerID("/Fotos/"+foto);
            productoBE.fotoBE.idFoto = idFoto;


            if (productoBC.AgregarProducto(productoBE) == true)
            {
                mensaje = "<script language='javascript' type='text/javascript'>" +
                                        "window.location.href=" +
                                        "'/Producto/ListarProductos';</script>";
            }
            else
            {
                mensaje = "<script language='javascript' type='text/javascript'>" +
                                        "alert('ERROR!!!...PRODUCTO No AGREGADO');window.location.href=" +
                                        "'/Producto/PagParaAgregarProducto';</script>";
            }

            return Content(mensaje);
        }



        public ActionResult EditarProducto(int idProducto)
        {
            List<CategoriaBE> listaCategoria = new List<CategoriaBE>();
            CategoriaBC categoriaBC = new CategoriaBC();
            listaCategoria = categoriaBC.ListaCategoria();
            ViewBag.ListaCategorias = listaCategoria;

            List<MarcaBE> listaMarca = new List<MarcaBE>();
            MarcaBC marcaBC = new MarcaBC();
            listaMarca = marcaBC.ListarMarcas();
            ViewBag.ListMarcas = listaMarca;

            UnidadDeMedidaBC unidadDeMedidaBC = new UnidadDeMedidaBC();
            List<UnidadDeMedidaBE> listaUnidadDeMedida = new List<UnidadDeMedidaBE>();
            listaUnidadDeMedida = unidadDeMedidaBC.ListarUnidadDeMedida();
            ViewBag.ListaUnidadDeMedida = listaUnidadDeMedida;

            EstadoBC estadoBC = new EstadoBC();
            List<EstadoBE> listaEstado = new List<EstadoBE>();
            listaEstado = estadoBC.ListarEstado();
            ViewBag.ListaEstado = listaEstado;


            FotoBC fotoBC = new FotoBC();
            List<FotoBE> listaFoto = new List<FotoBE>();
            listaFoto = fotoBC.ListarFoto();
            ViewBag.ListaFoto = listaFoto;

            return View(productoBC.BuscarProductoXid(idProducto));
        }

        public ActionResult ActualizarProducto(int txtIDprod, string txtDescripcion, int cboMarca, string txtMedida, int cboUnidadDeMedida, int txtUnidadesEnExistencia,
                                            DateTime dtFechaVencimiento, int cboEstado, double txtPrecio, string foto)
        {
            string mensaje = "";

            ProductoBE productoBE = new ProductoBE();
            productoBE.idProducto = txtIDprod;
            productoBE.descripcion = txtDescripcion;
            productoBE.marcaBE.idMarca = cboMarca;
            productoBE.medida = txtMedida;
            productoBE.unidadDeMedidaBE.idUnidad = cboUnidadDeMedida;
            productoBE.unidadesEnExistencia = txtUnidadesEnExistencia;
            productoBE.fechaVencimiento = dtFechaVencimiento;
            productoBE.estadoBE.idEstado = cboEstado;
            productoBE.precio = txtPrecio;

            int idFoto = fotoBC.ExisteFotoSINOagregar_ObtenerID("/Fotos/" + foto);
            productoBE.fotoBE.idFoto = idFoto;

            if (productoBC.ActualizarProducto(productoBE))
            {
                mensaje = "<script language='javascript' type='text/javascript'>" +
                                        "alert('PRODUCTO ACTUALIZADO');window.location.href=" +
                                        "'/Producto/ListarProductos';</script>";
            }
            else
            {
                mensaje = "<script language='javascript' type='text/javascript'>" +
                                       "alert('ERROR!!!...PRODUCTO No ACTUALIZADO');window.location.href=" +
                                       "'/Producto/EditarProducto';</script>";
            }
            return Content(mensaje);
        }


        public ActionResult EliminarProducto(int idProducto)
        {
            string mensaje = "";

            if (productoBC.EliminarProducto(idProducto) == true)
            {
                mensaje = "<script language='javascript' type='text/javascript'>" +
                                       "alert('PRODUCTO ELIMINADO!');window.location.href=" +
                                       "'/Producto/ListarProductos';</script>";
            }
            else
            {
                mensaje = "<script language='javascript' type='text/javascript'>" +
                                                      "alert('ERROR!!!...NO SE PUDO ELIMINAR EL PRODUCTO');window.location.href=" +
                                                      "'/Producto/ListarProductos';</script>";
            }

            return Content(mensaje);
        }


	}
}