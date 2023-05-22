namespace GestionLogisticaApiR.LogicaNegocio
{
    using GestionLogisticaApiR.AccesoDatos;
    using GestionLogisticaApiR.DTO;
    using GestionLogisticaApiR.LogicaNegocio.Validadores;
    using GestionLogisticaApiR.Models;

    public class PlanEntregaLN : IPlanEntregaLN
    {
        IValidadorPlanEntrega _validadorPlanEntrega;
        IGenericoAD<PlanEntrega> _planEntregaAD;
        IConsultaEntidadAD<Descuento> _descuentoAD;
        IGuardarEntidadAD<PlanEntrega_Vehiculo> _planEntregaVehiculoAD;
        IGuardarEntidadAD<PlanEntrega_Flota> _planEntregaFlotaAD;
        IGuardarEntidadAD<PlanEntrega_Bodega> _planEntregaBodegaAD;
        IGuardarEntidadAD<PlanEntrega_Puerto> _planEntregaPuertoAD;
        public PlanEntregaLN(IValidadorPlanEntrega validadorPlanEntrega, IGenericoAD<PlanEntrega> planEntregaAD, IConsultaEntidadAD<Descuento> descuentoAD,
           IGuardarEntidadAD<PlanEntrega_Vehiculo> planEntregaVehiculoAD, IGuardarEntidadAD<PlanEntrega_Flota> planEntregaFlotaAD,
           IGuardarEntidadAD<PlanEntrega_Bodega> planEntregaBodegaAD, IGuardarEntidadAD<PlanEntrega_Puerto> planEntregaPuertoAD)
        {
            _validadorPlanEntrega = validadorPlanEntrega;
            _planEntregaAD = planEntregaAD;
            _descuentoAD = descuentoAD;
            _planEntregaVehiculoAD = planEntregaVehiculoAD;
            _planEntregaFlotaAD = planEntregaFlotaAD;
            _planEntregaBodegaAD = planEntregaBodegaAD;
            _planEntregaPuertoAD = planEntregaPuertoAD;
        }
        public Cliente ConsultarPlanEntrega(string numeroGuia)
        {
            throw new NotImplementedException();
        }

        public string GuardarPlanEntrega(PlanEntrega planEntrega)
        {
            string? mensaje = string.Empty;
            ResultadoValidacion resultado = _validadorPlanEntrega.ValidarExistenciaEntidades(planEntrega.DocumentoCliente, planEntrega.TipoProducto, planEntrega.PuertoOBodega);

            if (resultado != null && resultado.ExisteRegistros)
            {
                if (resultado.IdTipoProducto == 1)
                {
                    if (_validadorPlanEntrega.ValidarNumeroPlaca(planEntrega.PlacaONumFlota))
                    {
                        planEntrega.Descuento = 0;
                        if (planEntrega.CantidadProducto > 10)
                        {
                            Descuento descuento = _descuentoAD.ConsultarEntidad(Convert.ToString(resultado.IdTipoProducto));
                            if (descuento != null)
                            {
                                planEntrega.Descuento = (planEntrega.PrecioEnvio * (descuento.Porcentaje / 100));
                            }
                        }
                        
                        _planEntregaAD.GuardarEntidad(planEntrega);
                        _planEntregaVehiculoAD.GuardarEntidad(new PlanEntrega_Vehiculo() { Placa = planEntrega.PlacaONumFlota, NumeroGuia = planEntrega.NumeroGuia});
                        _planEntregaBodegaAD.GuardarEntidad(new PlanEntrega_Bodega() { IdBodega = Convert.ToString(resultado.IdBodegaOPuerto), NumeroGuia = planEntrega.NumeroGuia });
                        mensaje = "Pan de entrega almacenado correctamente";
                    }
                    else
                    {
                        mensaje = "La Placa no es válida";
                    }

                }
                else
                {
                    if (_validadorPlanEntrega.ValidarNumeroFlota(planEntrega.PlacaONumFlota))
                    {
                        planEntrega.Descuento = 0;
                        if (planEntrega.CantidadProducto > 10)
                        {
                            Descuento descuento = _descuentoAD.ConsultarEntidad(Convert.ToString(resultado.IdTipoProducto));
                            if (descuento != null)
                            {
                                planEntrega.Descuento = (planEntrega.PrecioEnvio * (descuento.Porcentaje / 100));
                            }
                        }
                        
                        _planEntregaAD.GuardarEntidad(planEntrega);
                        _planEntregaFlotaAD.GuardarEntidad(new PlanEntrega_Flota() { NumeroFlota = planEntrega.PlacaONumFlota, NumeroGuia = planEntrega.NumeroGuia });
                        _planEntregaPuertoAD.GuardarEntidad(new PlanEntrega_Puerto() { NumeroGuia = planEntrega.NumeroGuia, IdPuerto = Convert.ToString(resultado.IdBodegaOPuerto)});
                        mensaje = "Pan de entrega almacenado correctamente";
                    }
                    else
                    {
                        mensaje = "El número de Flota no es válido";
                    }
                }
            }
            else
            {
                mensaje = resultado.Mensaje;
            }

            return mensaje;
        }




    }
}
