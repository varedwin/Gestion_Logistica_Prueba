namespace GestionLogisticaApiR.AccesoDatos
{
    using GestionLogisticaApiR.Models;
    using System.Data.SqlClient;

    public class ClienteAD : IGenericoAD<Cliente>
    {
        private const string _guardarCliente = "GuardarCliente";
        private const string _consultarCliente = "ConsultarCliente";

        public Cliente ConsultarEntidad(string parametro)
        {
            OrigenConexion cadena = new OrigenConexion();
            Cliente cliente = new Cliente();

            using (var conn = new SqlConnection(cadena.ConexionSQL))
            {
                conn.Open();
                var cmd = new SqlCommand(_consultarCliente, conn);
                cmd.Parameters.AddWithValue("@documento", parametro);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cliente.Documento = Convert.ToString(reader["Documento"]);
                        cliente.Nombres = Convert.ToString(reader["Nombres"]);
                        cliente.Apellidos = Convert.ToString(reader["Apellidos"]);
                        cliente.Direccion = Convert.ToString(reader["Direccion"]);
                        cliente.CorreoElectronico = Convert.ToString(reader["CorreoElectronico"]);

                    }
                }
            }

            return cliente;
        }

        public string GuardarEntidad(Cliente entidad)
        {
            OrigenConexion cadena = new OrigenConexion();
            string guardado = string.Empty;
            using (var conn = new SqlConnection(cadena.ConexionSQL))
            {
                conn.Open();
                var cmd = new SqlCommand(_guardarCliente, conn);
                cmd.Parameters.AddWithValue("@documento", entidad.Documento);
                cmd.Parameters.AddWithValue("@nombres", entidad.Nombres);
                cmd.Parameters.AddWithValue("@apellidos", entidad.Apellidos);
                cmd.Parameters.AddWithValue("@direccion", entidad.Direccion);
                cmd.Parameters.AddWithValue("@CorreoElectronico", entidad.CorreoElectronico);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                guardado = "Cliente almacenado correctamente";
            }

            return guardado;
        }
    }
}
