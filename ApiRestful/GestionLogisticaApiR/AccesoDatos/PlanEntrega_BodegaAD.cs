namespace GestionLogisticaApiR.AccesoDatos
{
    using GestionLogisticaApiR.Models;
    using System.Data.SqlClient;
    public class PlanEntrega_BodegaAD : IGuardarEntidadAD<PlanEntrega_Bodega>
    {
        private const string _guardarPlanEntregaBodega = "GuardarPlanEntregaBodega";
        public bool GuardarEntidad(PlanEntrega_Bodega entidad)
        {
            OrigenConexion cadena = new OrigenConexion();
            bool guardado = false;
            using (var conn = new SqlConnection(cadena.ConexionSQL))
            {
                conn.Open();
                var cmd = new SqlCommand(_guardarPlanEntregaBodega, conn);
                cmd.Parameters.AddWithValue("@numeroGuia", entidad.NumeroGuia);
                cmd.Parameters.AddWithValue("@idBodega", entidad.IdBodega);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                guardado = true;
            }

            return guardado;
        }
    }
}
