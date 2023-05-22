namespace GestionLogisticaApiR.AccesoDatos
{
    public interface IGenericoAD<T> where T : class
    {
        public string GuardarEntidad(T entidad);
        public T ConsultarEntidad(string? parametro);
    }
}
