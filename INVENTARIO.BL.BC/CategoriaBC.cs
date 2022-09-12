using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using INVENTARIO.BL.BE;
using INVENTARIO.DL.DALC;

namespace INVENTARIO.BL.BC
{
    public class CategoriaBC
    {
        CategoriaDALC categoriaDALC = new CategoriaDALC();

        public List<CategoriaBE> ListaCategoria()
        {
            return categoriaDALC.ListarCategorias();
        }
        public bool AgregarCategoria(CategoriaBE categoriaBE)
        {
            return categoriaDALC.AgregarCategoria(categoriaBE);
        }
    }
}
