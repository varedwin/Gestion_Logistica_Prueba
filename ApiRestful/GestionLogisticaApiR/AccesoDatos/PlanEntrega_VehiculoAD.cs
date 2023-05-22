﻿namespace GestionLogisticaApiR.AccesoDatos
{
    using GestionLogisticaApiR.Models;
    using System.Data.SqlClient;

    public class PlanEntrega_VehiculoAD : IGuardarEntidadAD<PlanEntrega_Vehiculo>
    {
        private const string _guardarPlanEntregaVehiculo = "GuardarPlanEntregaVehiculo";
        public bool GuardarEntidad(PlanEntrega_Vehiculo entidad)
        {
            OrigenConexion cadena = new OrigenConexion();
            bool guardado = false;
            using (var conn = new SqlConnection(cadena.ConexionSQL))
            {
                conn.Open();
                var cmd = new SqlCommand(_guardarPlanEntregaVehiculo, conn);
                cmd.Parameters.AddWithValue("@numeroGuia", entidad.NumeroGuia);
                cmd.Parameters.AddWithValue("@placaVehiculo", entidad.Placa);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                guardado = true;
            }

            return guardado;
        }
    }
}
