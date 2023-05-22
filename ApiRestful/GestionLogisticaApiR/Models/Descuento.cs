namespace GestionLogisticaApiR.Models
{
    public class Descuento
    {
        public int Id { get; set; }
        public decimal Porcentaje { get; set; }
        public int IdLogistica { get; set; }
    }
}
