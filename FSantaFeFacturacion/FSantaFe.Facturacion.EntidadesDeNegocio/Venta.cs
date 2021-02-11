using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSantaFe.Facturacion.EntidadesDeNegocio
{
    public class Venta
    {

        public int Id { get; set; }

        public int IdCliente { get; set; }

        public int IdUsuario { get; set; }

        public DateTime FechaVenta { get; set; }

        public int IdTipoComprobante { get; set; }

        public int Serie { get; set; }

        public int Correlativo { get; set; }

        public float Iva { get; set; }

        public float TotalVenta { get; set; }
    }
}
