using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INVENTARIO.BL.BE
{
    public class MarcaBE
    {
        public int idMarca { get; set; }
        public string marca { get; set; }
        public CategoriaBE categoriaBE { get; set; }
        public MarcaBE()
        {
            categoriaBE = new CategoriaBE();
        }
    }
}
