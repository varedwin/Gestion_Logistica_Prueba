namespace GestionLogisticaApiR.AccesoDatos
{
    using GestionLogisticaApiR.Models;
    using System.Data.SqlClient;
    public class PlanEntrega_PuertoAD : IGuardarEntidadAD<PlanEntrega_Puerto>
    {
        private const string _guardarPlanEntregaPuerto = "GuardarPlanEntregaPuerto";
        public bool GuardarEntidad(PlanEntrega_Puerto entidad)
        {
            OrigenConexion cadena = new OrigenConexion();
            bool guardado = false;
            using (var conn = new SqlConnection(cadena.ConexionSQL))
            {
                conn.Open();
                var cmd = new SqlCommand(_guardarPlanEntregaPuerto, conn);
                cmd.Parameters.AddWithValue("@numeroGuia", entidad.NumeroGuia);
                cmd.Parameters.AddWithValue("@idPuerto", entidad.IdPuerto);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                guardado = true;
            }

            return guardado;
        }
    }
}
