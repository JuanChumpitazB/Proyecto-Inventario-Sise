using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using INVENTARIO.BL.BE;
using INVENTARIO.DL.DALC;

namespace INVENTARIO.BL.BC
{
    public class ProductoBC
    {
        ProductoDALC productoDALC = new ProductoDALC();

        public List<ProductoBE> ListaProducto()
        {
            return productoDALC.ListarProductos();
        }

        public List<ProductoBE> ListarProductosOptimo()
        {
            return productoDALC.ListarProductosOptimo();
        }
        
        public List<ProductoBE> ListarProductosMerma()
        {
            return productoDALC.ListarProductosMerma();
        }
        
        public List<ProductoBE> ListarProductosXvencer()
        {
            return productoDALC.ListarProductosXvencer();
        }
        public List<ProductoBE> ProductosXagotarse()
        {
            return productoDALC.ProductosXagotarse();
        }
        public bool AgregarProducto(ProductoBE productoBE)
        {
            return productoDALC.AgregarProducto(productoBE);
        }
        public bool ActualizarProducto(ProductoBE productoBE)
        {
            return productoDALC.ActualizarProducto(productoBE);
        }
        public ProductoBE BuscarProductoXid(int idProducto)
        {
            return productoDALC.BuscarProductoXid(idProducto);
        }
        public bool EliminarProducto(int idProducto)
        {
            return productoDALC.EliminarProducto(idProducto);
        }
    }
}
