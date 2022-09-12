using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INVENTARIO.BL.BE
{
    public class ProductoBE
    {
        public int idProducto { get; set; }
        public string descripcion { get; set; }
        public MarcaBE marcaBE { get; set; }
        public string medida { get; set; }
        public UnidadDeMedidaBE unidadDeMedidaBE { get; set; }
        public int unidadesEnExistencia { get; set; }
        public DateTime fechaVencimiento { get; set; }
        public EstadoBE estadoBE { get; set; }
        public double precio {get;set;}
        public FotoBE fotoBE { get; set; }



        public ProductoBE ()
        {
            marcaBE = new MarcaBE();
            unidadDeMedidaBE = new UnidadDeMedidaBE();
            estadoBE = new EstadoBE();
            fotoBE = new FotoBE();
        }


    }
}
