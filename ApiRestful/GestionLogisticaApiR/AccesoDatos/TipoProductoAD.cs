using GestionLogisticaApiR.Models;
using System.Data.SqlClient;

namespace GestionLogisticaApiR.AccesoDatos
{
    public class TipoProductoAD : IGenericoAD<TipoProducto>
    {
        private const string _guardarTipoProducto = "GuardarTipoProducto";
        private const string _consultarTipoProducto = "ConsultarTipoProducto";

        public TipoProducto ConsultarEntidad(string parametro)
        {
            OrigenConexion cadena = new OrigenConexion();
            TipoProducto tipoProducto = new TipoProducto();

            using (var conn = new SqlConnection(cadena.ConexionSQL))
            {
                conn.Open();
                var cmd = new SqlCommand(_consultarTipoProducto, conn);
                cmd.Parameters.AddWithValue("@id", parametro);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tipoProducto.Id = Convert.ToInt32(reader["Id"]);
                        tipoProducto.Nombre = Convert.ToString(reader["Nombre"]);
                        tipoProducto.IdLogistica = Convert.ToInt32(reader["IdLogistica"]);
                        
                    }
                }
            }

            return tipoProducto;
        }

        public string GuardarEntidad(TipoProducto entidad)
        {
            OrigenConexion cadena = new OrigenConexion();
            string guardado = string.Empty;
            using (var conn = new SqlConnection(cadena.ConexionSQL))
            {
                conn.Open();
                var cmd = new SqlCommand(_guardarTipoProducto, conn);
                cmd.Parameters.AddWithValue("@nombre", entidad.Nombre);
                cmd.Parameters.AddWithValue("@idLogistica", entidad.IdLogistica);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                guardado = "El registro se guardó correctamente";
            }

            return guardado;
        }
    }
}
