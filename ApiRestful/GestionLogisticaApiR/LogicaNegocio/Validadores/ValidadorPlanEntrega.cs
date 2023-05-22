namespace GestionLogisticaApiR.LogicaNegocio.Validadores
{
    using GestionLogisticaApiR.AccesoDatos;
    using GestionLogisticaApiR.DTO;
    using GestionLogisticaApiR.Models;
    using System.Text.RegularExpressions;
    public class ValidadorPlanEntrega : IValidadorPlanEntrega
    {
        private IGenericoAD<Cliente> _clienteAD;
        private IGenericoAD<TipoProducto> _tipoProductoAD;
        private IConsultaEntidadAD<Bodega> _bodegaAD;
        private IConsultaEntidadAD<Puerto> _puertoAD;
        public ValidadorPlanEntrega(IGenericoAD<Cliente> clienteAD, IGenericoAD<TipoProducto> tipoProductoAD, IConsultaEntidadAD<Bodega> bodegaAD, 
            IConsultaEntidadAD<Puerto> puertoAD)
        {
            _clienteAD = clienteAD;
            _tipoProductoAD = tipoProductoAD;
            _bodegaAD = bodegaAD;
            _puertoAD = puertoAD;
        }

        /// <summary>
        /// Método que verifica si están creados los registros del cliente, tipo producto, bodega y puerto para crear posteriormente
        /// el Plan de entrega
        /// </summary>
        /// <param name="documento"></param>
        /// <param name="idTipoProducto"></param>
        /// <param name="nombreLocacion"></param>
        /// <returns></returns>
        public ResultadoValidacion ValidarExistenciaEntidades(string? documento, string? idTipoProducto, string? nombreLocacion)
        {
            ResultadoValidacion validacion = new ResultadoValidacion();

            Cliente clienteTmp = _clienteAD.ConsultarEntidad(documento);
            
            if(clienteTmp != null && clienteTmp.Documento == documento) {

              TipoProducto tipoProdTmp =  _tipoProductoAD.ConsultarEntidad(idTipoProducto);

                if(tipoProdTmp != null && Convert.ToString(tipoProdTmp.Id) == idTipoProducto)
                {
                    if(tipoProdTmp.IdLogistica == 1)
                    {
                        Bodega bodegaTmp = _bodegaAD.ConsultarEntidad(nombreLocacion);

                        if(bodegaTmp != null && bodegaTmp.Nombre == nombreLocacion)
                        {
                            validacion.Mensaje = "Registros existen";
                            validacion.IdTipoProducto = tipoProdTmp.IdLogistica;
                            validacion.IdBodegaOPuerto = bodegaTmp.Id;
                            validacion.ExisteRegistros = true;
                        }
                        else
                        {
                            validacion.Mensaje = "El registro de la Bodega no está creado";
                            validacion.ExisteRegistros = false;
                        }
                    }
                    else
                    {

                        Puerto puertoTmp = _puertoAD.ConsultarEntidad(nombreLocacion);

                        if(puertoTmp != null && puertoTmp.Nombre == nombreLocacion)
                        {
                            validacion.Mensaje = "Registros existen";
                            validacion.IdTipoProducto = tipoProdTmp.IdLogistica;
                            validacion.IdBodegaOPuerto = puertoTmp.Id;
                            validacion.ExisteRegistros = true;
                        }
                        else
                        {
                            validacion.Mensaje = "El registro del puerto no está creado";
                            validacion.ExisteRegistros = false;
                        }

                    }

                }
                else
                {
                    validacion.Mensaje = "El registro Tipo producto no está creado";
                    validacion.ExisteRegistros = false;
                }

            }
            else
            {
                validacion.Mensaje = "El registro cliente no está creado";
                validacion.ExisteRegistros = false;
            }

            return validacion;
        }

        public bool ValidarNumeroGuia(string numeroGuia)
        {
            Regex regex = new Regex(@"^[a-zA-Z0-9]{10}$");
            return regex.IsMatch(numeroGuia);
        }


        public bool ValidarNumeroPlaca(string numeroPlaca)
        {
            Regex regex = new Regex(@"^[a-zA-Z]{3}\d{3}$");
            return regex.IsMatch(numeroPlaca);
        }

        public bool ValidarNumeroFlota(string numeroFlota)
        {
            Regex regex = new Regex(@"^[a-zA-Z]{3}\d{4}[a-zA-Z]$");
            return regex.IsMatch(numeroFlota);
        }
    }
}
