using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INVENTARIO.BL.BE
{
    public class UsuarioBE
    {
        public int idUsuario {get;set;}
        public string nombres { get; set; }
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }
        public string dni { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public string ususario { get; set; }
        public string password { get; set; }
        public int intentos { get; set; }
        public byte estado { get; set; }
        public RolBE rolBE { get; set; }

        public UsuarioBE()
        {
            rolBE = new RolBE();
        }
    }
}
