using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using INVENTARIO.BL.BE;
using INVENTARIO.DL.DALC;

namespace INVENTARIO.BL.BC
{
    public class MarcaBC
    {
        MarcaDALC marcaDALC = new MarcaDALC();

        public List<MarcaBE> ListarMarcas()
        {
            return marcaDALC.ListarMarcas();
        }

        public MarcaBE BuscarMarcasXCategoria(int idCategoria)
        {
            return marcaDALC.BuscarMarcasXCategoria(idCategoria);
        }
        public bool AgregarMarca(MarcaBE marcaBE)
        {
            return marcaDALC.AgregarMarca(marcaBE);
        }
    }
}
