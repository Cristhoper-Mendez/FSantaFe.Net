using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSantaFe.Facturacion.EntidadesDeNegocio
{
    public class Producto
    {
        public int Id { get; set; }

        public int Codigo { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public int MyProperty { get; set; }

        public bool Existencia { get; set; }

        public float PrecioCosto { get; set; }

        public float PrecioVenta { get; set; }

        public int StockMinimo { get; set; }

        public int StockMaximo { get; set; }

        public int IdCategoria { get; set; }

        public int IdMarca { get; set; }

        public int IdTipoMaterial { get; set; }

        public int IdEstado { get; set; }
    }
}
