using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSantaFe.Facturacion.EntidadesDeNegocio
{
    public class TipoComprobante
    {

        public byte Id { get; set; }

        public String NombreTipo { get; set; }

        public byte IdEstado { get; set; }
    }
}
