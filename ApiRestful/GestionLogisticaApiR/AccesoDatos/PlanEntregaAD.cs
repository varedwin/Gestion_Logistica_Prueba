namespace GestionLogisticaApiR.AccesoDatos
{
    using GestionLogisticaApiR.Models;
    using System.Data.SqlClient;

    public class PlanEntregaAD : IGenericoAD<PlanEntrega>
    {
        private const string _guardarPlanEntrega = "GuardarPlanEntrega";
        private const string _consultarPlanEntrega = "ConsultarPlanEntrega";

        public PlanEntrega ConsultarEntidad(string parametro)
        {
            OrigenConexion cadena = new OrigenConexion();
            PlanEntrega planEntrega = new PlanEntrega();

            using (var conn = new SqlConnection(cadena.ConexionSQL))
            {
                conn.Open();
                var cmd = new SqlCommand(_consultarPlanEntrega, conn);
                cmd.Parameters.AddWithValue("@numeroGuia", parametro);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        planEntrega.NumeroGuia = Convert.ToString(reader["NumeroGuia"]);
                        planEntrega.TipoProducto = Convert.ToString(reader["TipoProducto"]);
                        planEntrega.CantidadProducto = Convert.ToDecimal(reader["CantidadProducto"]);
                        planEntrega.FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]);
                        planEntrega.FechaEntrega = Convert.ToDateTime(reader["FechaEntrega"]);
                        planEntrega.PrecioEnvio = Convert.ToDecimal(reader["PrecioEnvio"]);
                        planEntrega.DocumentoCliente = Convert.ToString(reader["DocumentoCliente"]);
                        planEntrega.Descuento = Convert.ToDecimal(reader["Descuento"]);

                    }
                }
            }

            return planEntrega;
        }

        public string GuardarEntidad(PlanEntrega entidad)
        {
            OrigenConexion cadena = new OrigenConexion();
            string guardado = string.Empty;
            using (var conn = new SqlConnection(cadena.ConexionSQL))
            {
                conn.Open();
                var cmd = new SqlCommand(_guardarPlanEntrega, conn);
                cmd.Parameters.AddWithValue("@numeroGuia", entidad.NumeroGuia);
                cmd.Parameters.AddWithValue("@tipoProducto", entidad.TipoProducto);
                cmd.Parameters.AddWithValue("@cantidadProducto", entidad.CantidadProducto);
                cmd.Parameters.AddWithValue("@fechaRegistro", entidad.FechaRegistro);
                cmd.Parameters.AddWithValue("@fechaEntrega", entidad.FechaEntrega);
                cmd.Parameters.AddWithValue("@precioEnvio", entidad.PrecioEnvio);
                cmd.Parameters.AddWithValue("@documentoCliente", entidad.DocumentoCliente);
                cmd.Parameters.AddWithValue("@descuento", entidad.Descuento);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                guardado = "El registro se guardó correctamente";
            }

            return guardado;
        }
    }
}
