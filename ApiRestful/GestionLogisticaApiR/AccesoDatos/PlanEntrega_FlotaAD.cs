namespace GestionLogisticaApiR.AccesoDatos
{
    using GestionLogisticaApiR.Models;
    using System.Data.SqlClient;

    public class PlanEntrega_FlotaAD : IGuardarEntidadAD<PlanEntrega_Flota>
    {
        private const string _guardarPlanEntregaFlota = "GuardarPlanEntregaFlota";
        public bool GuardarEntidad(PlanEntrega_Flota entidad)
        {
            OrigenConexion cadena = new OrigenConexion();
            bool guardado = false;
            using (var conn = new SqlConnection(cadena.ConexionSQL))
            {
                conn.Open();
                var cmd = new SqlCommand(_guardarPlanEntregaFlota, conn);
                cmd.Parameters.AddWithValue("@numeroGuia", entidad.NumeroGuia);
                cmd.Parameters.AddWithValue("@numeroFlota", entidad.NumeroFlota);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                guardado = true;
            }

            return guardado;
        }
    }
}
