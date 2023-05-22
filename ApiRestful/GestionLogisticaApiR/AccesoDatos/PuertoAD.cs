namespace GestionLogisticaApiR.AccesoDatos
{
    using GestionLogisticaApiR.Models;
    using System.Data.SqlClient;
    public class PuertoAD : IConsultaEntidadAD<Puerto>
    {
        private const string _consultarPuerto = "ConsultarPuerto";
        public Puerto ConsultarEntidad(string nombre)
        {
            OrigenConexion cadena = new OrigenConexion();
            Puerto puerto = new Puerto();

            using (var conn = new SqlConnection(cadena.ConexionSQL))
            {
                conn.Open();
                var cmd = new SqlCommand(_consultarPuerto, conn);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        puerto.Id = Convert.ToInt32(reader["Id"]);
                        puerto.Nombre = Convert.ToString(reader["Nombre"]);
                        puerto.IdCiudad = Convert.ToInt32(reader["IdCiudad"]);
                    }
                }
            }

            return puerto;
        }
    }
}
