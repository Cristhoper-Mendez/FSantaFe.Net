using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using FSantaFe.Facturacion.EntidadesDeNegocio;

namespace FSantaF.Facturacion.AccesoADatos
{
    public class CargoDAL
    {
        public static int Guardar(Cargo pCargo) {
            string consulta = "INSERT INTO Cargo( IdEstado, Nombre) VALUES(@IdEstado, @Nombre)";

            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;

            comando.Parameters.AddWithValue("@IdEstado", pCargo.IdEstado);
            comando.Parameters.AddWithValue("@Nombre", pCargo.Nombre);

            return ComunDB.EjecutarComando(comando);
        }

        public static int Modificar(Cargo pCargo) {
            string consulta = @"UPDATE Cargo SET Nombre=@Nombre, IdEstado=@IdEstado WHERE Id=@Id";

            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;

            comando.Parameters.AddWithValue("@Nombre", pCargo.Nombre);
            comando.Parameters.AddWithValue("@Id", pCargo.Id);
            comando.Parameters.AddWithValue("@IdEstado", pCargo.IdEstado);

            return ComunDB.EjecutarComando(comando);

        }

        public static int Eliminar(Cargo pCargo) {
            string consulta = "DELETE FROM Cargo WHERE Id=@Id";

            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;

            comando.Parameters.AddWithValue("@Id", pCargo.Id);

            return ComunDB.EjecutarComando(comando);
        }

        public static List<Cargo> ObtenerTodos() {
            string consulta = "SELECT TOP 500 c.Id, c.IdEstado, c.Nombre FROM Cargo c";

            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;

            SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);

            List<Cargo> ListaCargos = new List<Cargo>();

            while (reader.Read())
            {
                Cargo cargo = new Cargo();

                cargo.Id = reader.GetByte(0);
                cargo.IdEstado = reader.GetByte(1);
                cargo.Nombre = reader.GetString(2);

                ListaCargos.Add(cargo);
            }

            return ListaCargos;
        }

        public static Cargo ObtenerPorId(byte pId) {
            string consulta = "SELECT c.Id, C.IdEstado, c.Nombre FROM Cargo c WHERE c.Id=@Id";

            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;
            comando.Parameters.AddWithValue("@Id", pId);

            SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);

            Cargo cargo = new Cargo();

            while (reader.Read())
            {
                cargo.Id = reader.GetByte(0);
                cargo.IdEstado = reader.GetByte(1);
                cargo.Nombre = reader.GetString(2);
            }

            return cargo;
        }

        public static List<Cargo> ObtenerHabilitados()
        {
            string consulta = "SELECT TOP 500 c.Id, c.IdEstado, c.Nombre FROM Cargo c WHERE IdEstado=1";

            SqlCommand comando = ComunDB.ObtenerComando();
            comando.CommandText = consulta;

            SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);

            List<Cargo> ListaCargos = new List<Cargo>();

            while (reader.Read())
            {
                Cargo cargo = new Cargo();

                cargo.Id = reader.GetByte(0);
                cargo.IdEstado = reader.GetByte(1);
                cargo.Nombre = reader.GetString(2);

                ListaCargos.Add(cargo);
            }

            return ListaCargos;
        }
        public static List<Cargo> Buscar(Cargo pCargo) { 
            string consulta = "SELECT TOP 500 c.Id, c.IdEstado, c.Nombre FROM Cargo c";
            string wheresql = " "; // agrega condiciones a las consultas segun los campos buscados
            byte contadoCampos = 0; // sirve para saber si agregar AND a la consulta

            SqlCommand comando = ComunDB.ObtenerComando();

            // agregar condiciones a la consulta para obtener los registros filtrados por los campos de busueda
            if(pCargo.IdEstado > 0) {  // verificar que la propiedad IdEstado tenga informacion que buscar
                if (contadoCampos > 0) {
                    wheresql += " AND "; //SELECT TOP 500 c.Id, c.IdEstado, c.Nombre FROM Cargo c WHERE IdEstado=@IdEstado
                }

                contadoCampos++;
                wheresql += " IdEstado = @IdEstado";
                comando.Parameters.AddWithValue("@IdEstado", pCargo.IdEstado);
            }

            if(pCargo.Nombre != null && pCargo.Nombre.Trim().Length > 0) { //verificar que nombre tenga informacion para buscar
                if(contadoCampos > 0) {
                    wheresql += " AND "; //SELECT TOP 500 c.Id, c.IdEstado, c.Nombre FROM Cargo c WHERE IdEstado=@IdEstado AND Nombre LIKE Nombre
                }
                contadoCampos++;
                wheresql += " Nombre LIKE @Nombre ";
                comando.Parameters.AddWithValue("@Nombre", '%' + pCargo.Nombre + '%');
            }

            if (wheresql.Trim().Length > 0){// verificar si hay texto
                wheresql = " WHERE " + wheresql; // 
            }

            comando.CommandText = consulta + wheresql;

            SqlDataReader reader = ComunDB.EjecutarComandoReader(comando);
            List<Cargo> ListaCargos = new List<Cargo>();

            while (reader.Read())
            {
                Cargo cargo = new Cargo();

                cargo.Id = reader.GetByte(0);
                cargo.IdEstado = reader.GetByte(1);
                cargo.Nombre = reader.GetString(2);

                ListaCargos.Add(cargo);
            }

            comando.Connection.Dispose();

            return ListaCargos;

        }

    }
}
