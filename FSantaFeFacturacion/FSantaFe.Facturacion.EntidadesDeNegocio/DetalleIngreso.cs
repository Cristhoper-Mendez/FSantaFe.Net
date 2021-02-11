using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 13
 */

namespace FSantaFe.Facturacion.EntidadesDeNegocio
{
    public class DetalleIngreso
    {
        public int Id { get; set; }

        public int IdIngreso { get; set; }

        public int IdProducto { get; set; }

        public float PrecioCompra { get; set; }

        public float PrecioVenta { get; set; }

        public int StockActual { get; set; }

        public DateTime FechaProduccion { get; set; }

        public DateTime FechaVencimiento { get; set; }
    }
}
