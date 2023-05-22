namespace GestionLogisticaApiR.AccesoDatos
{
    using GestionLogisticaApiR.Models;
    using System.Data.SqlClient;
    public class BodegaAD : IConsultaEntidadAD<Bodega>
    {
        private const string _consultarBodega = "ConsultarBodega";
        public Bodega ConsultarEntidad(string nombre)
        {
            OrigenConexion cadena = new OrigenConexion();
            Bodega bodega = new Bodega();

            using (var conn = new SqlConnection(cadena.ConexionSQL))
            {
                conn.Open();
                var cmd = new SqlCommand(_consultarBodega, conn);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        bodega.Id = Convert.ToInt32(reader["Id"]);
                        bodega.Nombre = Convert.ToString(reader["Nombre"]);
                        bodega.Direccion = Convert.ToString(reader["Direccion"]);
                        bodega.IdCiudad = Convert.ToInt32(reader["IdCiudad"]);
                    }
                }
            }

            return bodega;
        }
    }
}
