using GestionLogisticaApiR.AccesoDatos;
using GestionLogisticaApiR.Models;

namespace GestionLogisticaApiR.LogicaNegocio
{
    public interface ILogisticaGeneralLN
    {
        public string GuardarCliente(Cliente cliente);
        public Cliente ConsultarCliente(string documento);
        public string GuardarTipoProducto(TipoProducto tipoProducto);
        public TipoProducto ConsultarTipoProducto(string id);

    }
}
