﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSantaFe.Facturacion.EntidadesDeNegocio
{
    public class Municipio
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public int IdDepartamento { get; set; }

        public int IdEstado { get; set; }
    }
}
