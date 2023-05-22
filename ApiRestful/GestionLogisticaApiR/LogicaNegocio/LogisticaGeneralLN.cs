namespace GestionLogisticaApiR.LogicaNegocio
{
    using GestionLogisticaApiR.AccesoDatos;
    using GestionLogisticaApiR.Models;

    public class LogisticaGeneralLN : ILogisticaGeneralLN
    {
        private IGenericoAD<Cliente> _clienteAD;
        private IGenericoAD<TipoProducto> _tipoProductoAD;

        public LogisticaGeneralLN(IGenericoAD<Cliente> clienteAD , IGenericoAD<TipoProducto> tipoProductoAD)
        {
            _clienteAD = clienteAD;
            _tipoProductoAD = tipoProductoAD;
        }

        public Cliente ConsultarCliente(string documento)
        {
            return _clienteAD.ConsultarEntidad(documento);
        }

        public string GuardarTipoProducto(TipoProducto tipoProducto)
        {
            return _tipoProductoAD.GuardarEntidad(tipoProducto);
        }

        public TipoProducto ConsultarTipoProducto(string id)
        {
            return _tipoProductoAD.ConsultarEntidad(id);
        }

        public string GuardarCliente(Cliente cliente)
        {
            return _clienteAD.GuardarEntidad(cliente);
        }

    }
}
