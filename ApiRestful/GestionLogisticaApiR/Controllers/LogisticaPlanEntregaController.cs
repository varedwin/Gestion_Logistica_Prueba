
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace GestionLogisticaApiR.Controllers
{
    using GestionLogisticaApiR.DTO;
    using GestionLogisticaApiR.LogicaNegocio;
    using GestionLogisticaApiR.Models;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class LogisticaPlanEntregaController : ControllerBase
    {
        private IPlanEntregaLN _planEntregaLN;
        public LogisticaPlanEntregaController(IPlanEntregaLN planEntregaLN)
        {
            _planEntregaLN = planEntregaLN;
        }


        [HttpPost("GuardarPlanEntrega")]
        public ActionResult<Respuesta> GuardarPlanEntrega(PlanEntrega planEntrega)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta.Descripcion = _planEntregaLN.GuardarPlanEntrega(planEntrega);
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
