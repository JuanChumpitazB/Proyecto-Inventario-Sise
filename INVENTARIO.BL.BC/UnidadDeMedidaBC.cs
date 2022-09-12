using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using INVENTARIO.BL.BE;
using INVENTARIO.DL.DALC;

namespace INVENTARIO.BL.BC
{
    public class UnidadDeMedidaBC
    {
        UnidadDeMedidaDALC unidadDeMedidaDALC = new UnidadDeMedidaDALC();

        public List<UnidadDeMedidaBE> ListarUnidadDeMedida()
        {
            return unidadDeMedidaDALC.ListarMarcas();
        }
        public bool AgregarUnidadDeMedida(UnidadDeMedidaBE unidadDeMedidaBE)
        {
            return unidadDeMedidaDALC.AgregarUnidadDeMedida(unidadDeMedidaBE);
        }
    }
}
