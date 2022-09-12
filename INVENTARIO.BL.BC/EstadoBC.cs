using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using INVENTARIO.BL.BE;
using INVENTARIO.DL.DALC;

namespace INVENTARIO.BL.BC
{
    public class EstadoBC
    {
        EstadoDALC estadoDALC = new EstadoDALC();

        public List<EstadoBE> ListarEstado()
        {
            return estadoDALC.ListarEstado();
        }
        public bool AgregarEstado(EstadoBE estadoBE)
        {
            return estadoDALC.AgregarEstado(estadoBE);
        }
    }
}
