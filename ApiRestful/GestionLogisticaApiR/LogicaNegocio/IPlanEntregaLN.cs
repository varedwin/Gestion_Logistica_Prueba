using GestionLogisticaApiR.Models;

namespace GestionLogisticaApiR.LogicaNegocio
{
    public interface IPlanEntregaLN
    {
        public string GuardarPlanEntrega(PlanEntrega planEntrega);
        public Cliente ConsultarPlanEntrega(string numeroGuia);
    }
}
