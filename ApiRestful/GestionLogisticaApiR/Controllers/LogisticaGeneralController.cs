namespace GestionLogisticaApiR.Controllers
{
    using GestionLogisticaApiR.DTO;
    using GestionLogisticaApiR.LogicaNegocio;
    using GestionLogisticaApiR.Models;
    using Microsoft.AspNetCore.Mvc;


    [Route("api/[controller]")]
    [ApiController]
    public class LogisticaGeneralController : ControllerBase
    {
        ILogisticaGeneralLN _logisticaGeneralLN;
        public LogisticaGeneralController(ILogisticaGeneralLN logisticaGeneralLN)
        {
            _logisticaGeneralLN = logisticaGeneralLN;
        }

        [HttpGet("ConsultarCliente")]
        public ActionResult<Cliente> ConsultarCliente(string documento)
        {
            try
            {
                return _logisticaGeneralLN.ConsultarCliente(documento);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }

        [HttpPost("GuardarCliente")]
        public ActionResult<Respuesta> GuardarCliente(Cliente cliente)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta.Descripcion = _logisticaGeneralLN.GuardarCliente(cliente);
                respuesta.Codigo = "200";
                return respuesta;

            }
            catch (Exception)
            {
                respuesta.Descripcion = "Error Interno";
                respuesta.Codigo = "500";
                return respuesta;

            }

        }

        [HttpGet("ConsultarTipoProducto")]
        public ActionResult<TipoProducto> ConsultarTipoProducto(string id)
        {
            try
            {
                return _logisticaGeneralLN.ConsultarTipoProducto(id);

            }
            catch (Exception)
            {
                return StatusCode(500);

            }

        }

        [HttpPost("GuardarTipoProducto")]
        public ActionResult<Respuesta> GuardarTipoProducto(TipoProducto tipoProducto)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta.Descripcion = _logisticaGeneralLN.GuardarTipoProducto(tipoProducto);
                respuesta.Codigo = "200";
                return respuesta;

            }
            catch (Exception)
            {
                respuesta.Descripcion = "Error Interno";
                respuesta.Codigo = "500";
                return respuesta;

            }

        }
    }
}
