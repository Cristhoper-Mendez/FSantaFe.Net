using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSantaFe.Facturacion.EntidadesDeNegocio
{
    public class Empleado
    {
        public Int16 Id{ get; set; }
        public byte IdCargo{ get; set; }

        public byte IdEstado { get; set; }

        public string NumeroDUI { get; set; }

        public string Nombres { get; set; }

        public string Apellidos { get; set; }

        public string Sexo { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string Direccion { get; set; }

        public string telefono { get; set; }
    }
}
