using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSantaFe.Facturacion.EntidadesDeNegocio
{
    public class Usuario
    {
        public byte Id { get; set; }

        public int IdEmpleado { get; set; }

        public string Nombre { get; set; }

        public string Clave { get; set; }

        public int IdEstado { get; set; }
    }
}
