using GestionLogisticaApiR.DTO;
using System.Text.RegularExpressions;

namespace GestionLogisticaApiR.LogicaNegocio.Validadores
{
    public interface IValidadorPlanEntrega
    {
        public ResultadoValidacion ValidarExistenciaEntidades(string? documento, string? idTipoProducto, string? nombreLocacion);
        public bool ValidarNumeroGuia(string numeroGuia);
        public bool ValidarNumeroPlaca(string? numeroPlaca);
        public bool ValidarNumeroFlota(string? numeroFlota);
    }
}
