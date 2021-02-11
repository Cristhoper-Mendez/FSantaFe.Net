using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSantaFe.Facturacion.EntidadesDeNegocio
{
    public class Proveedor
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string RazonSocial { get; set; }

        public string SectorComercial { get; set; }

        public int IdTipoDocumento { get; set; }

        public string NumeroDocumento { get; set; }

        public string Direccion { get; set; }

        public int IdMunicipio { get; set; }

        public string Telefono { get; set; }

        public string Correo { get; set; }

        public string SitioWeb { get; set; }

        public int IdEstado { get; set; }

    }
}
