using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSantaFe.Facturacion.EntidadesDeNegocio
{
    public class Cliente
    {
        public int Id { get; set; }

        public string Nombres { get; set; }

        public string Apellidos { get; set; }

        public string Sexo { get; set; }

        public DateTime FechaNacimineto { get; set; }

        public int IdTipoDocumento { get; set; }

        public string NumeroDocumento { get; set; }

        public string Direccion { get; set; }

        public int IdMunicipio { get; set; }

        public string Telefono { get; set; }

        public string Correo { get; set; }

        public int IdEstado { get; set; }
    }
}
