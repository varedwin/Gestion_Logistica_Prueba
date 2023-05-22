namespace GestionLogisticaApiR.DTO
{
    public class ResultadoValidacion
    {
        public bool ExisteRegistros { get; set; }
        public string? Mensaje { get; set; }
        public int IdTipoProducto { get; set; }
        public int IdBodegaOPuerto { get; set; }
    }
}
