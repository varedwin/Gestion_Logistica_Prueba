namespace GestionLogisticaApiR.AccesoDatos
{
    public interface IConsultaEntidadAD<T> where T : class
    {
        public T ConsultarEntidad(string? nombre);

    }
}
