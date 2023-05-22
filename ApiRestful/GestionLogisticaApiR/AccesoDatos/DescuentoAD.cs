namespace GestionLogisticaApiR.AccesoDatos
{
    using GestionLogisticaApiR.Models;
    using System.Data.SqlClient;

    public class DescuentoAD : IConsultaEntidadAD<Descuento>
    {
        private const string _consultarDescuento = "ConsultarDescuento";
        public Descuento ConsultarEntidad(string? nombre)
        {
            OrigenConexion cadena = new OrigenConexion();
            Descuento descuento = new Descuento();

            using (var conn = new SqlConnection(cadena.ConexionSQL))
            {
                conn.Open();
                var cmd = new SqlCommand(_consultarDescuento, conn);
                cmd.Parameters.AddWithValue("@idLogistica", nombre);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        descuento.Id = Convert.ToInt32(reader["Id"]);
                        descuento.Porcentaje = Convert.ToDecimal(reader["Porcentaje"]);
                        descuento.IdLogistica = Convert.ToInt32(reader["IdLogistica"]);
                    }
                }
            }

            return descuento;
        }
    }
}
