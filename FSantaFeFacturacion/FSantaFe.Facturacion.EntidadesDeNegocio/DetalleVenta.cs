using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSantaFe.Facturacion.EntidadesDeNegocio
{
    public class DetalleVenta
    {
        public int Id { get; set; }

        public int IdVenta { get; set; }

        public int Cantidad { get; set; }

        public float PrecioCosto { get; set; }

        public float PrecioVenta { get; set; }

        public float SubTotalVenta { get; set; }

        public float Descuento { get; set; }
    }
}
