using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using INVENTARIO.BL.BE;
using INVENTARIO.DL.DALC;

namespace INVENTARIO.BL.BC
{
    public class RolBC
    {
        RolDALC rolDALC = new RolDALC();
        public List<RolBE> ListarRol()
        {
            return rolDALC.ListarRol();
        }
    }
}
