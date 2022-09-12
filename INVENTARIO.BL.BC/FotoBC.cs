using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using INVENTARIO.BL.BE;
using INVENTARIO.DL.DALC;

namespace INVENTARIO.BL.BC
{
    public class FotoBC
    {
        FotoDALC fotoDALC = new FotoDALC();

        public List<FotoBE> ListarFoto()
        {
            return fotoDALC.ListaFoto();
        }
        public int ExisteFotoSINOagregar_ObtenerID(string url)
        {
            return fotoDALC.ExisteFotoSINOagregar_ObtenerID(url);
        }
        public bool AgregarFoto(FotoBE fotoBE)
        {
            return fotoDALC.AgregarFoto(fotoBE);
        }
    }
}
