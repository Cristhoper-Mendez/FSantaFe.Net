using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using FSantaF.Facturacion.AccesoADatos;
using FSantaFe.Facturacion.EntidadesDeNegocio;

namespace FSantaF.Facturacion.LogicaDeNegocio
{
    public class EstadoBL
    {
        public static int Guardar(Estado pEstado) {
            return EstadoDAL.Guardar(pEstado);
        }

        public static int Modificar(Estado pEstado) {
            return EstadoDAL.Modificar(pEstado);
        }

        public static int Eliminar(Estado pEstado){
            return EstadoDAL.Eliminar(pEstado);
        }

        public static List<Estado> ObtenerTodos() {
            return EstadoDAL.ObtenerTodos();
        }

        public static Estado ObtenerEstadoId(byte pId) {
            return EstadoDAL.ObtenerPorId(pId);
        }
    }
}
