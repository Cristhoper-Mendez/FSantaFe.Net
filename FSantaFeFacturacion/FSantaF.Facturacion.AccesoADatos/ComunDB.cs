using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
/*
 DESKTOP-URUNQ5U\SQLEXPRESS
 */

namespace FSantaF.Facturacion.AccesoADatos
{
    public class ComunDB
    {
        const string StrConeccion = @"Data Source=DESKTOP-URUNQ5U\SQLEXPRESS;Initial Catalog=Facturacion;Integrated Security=True";

        private static SqlConnection ObtenerConeccion(){
            SqlConnection connection = new SqlConnection(StrConeccion);

            connection.Open();

            return connection;
        }

        public static SqlCommand ObtenerComando() {
            SqlCommand command = new SqlCommand();

            command.Connection = ObtenerConeccion();

            return command;
        }

        public static int EjecutarComando(SqlCommand pComando) {
            int resultado = pComando.ExecuteNonQuery();

            pComando.Connection.Close();

            return resultado;
        }

        public static SqlDataReader EjecutarComandoReader(SqlCommand pComando) {
            SqlDataReader reader = pComando.ExecuteReader(CommandBehavior.CloseConnection);

            return reader;
        }
    }
}
