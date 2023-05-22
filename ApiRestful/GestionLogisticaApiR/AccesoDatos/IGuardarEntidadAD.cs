namespace GestionLogisticaApiR.AccesoDatos
{
    public interface IGuardarEntidadAD<T> where T : class
    {
        public bool GuardarEntidad(T entidad);
    }
}
