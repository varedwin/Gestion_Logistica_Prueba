using System.ComponentModel.DataAnnotations;

namespace GestionLogisticaApiR.Models
{
    public class PlanEntrega
    {
        [RegularExpression(@"^[a-zA-Z]{3}\d{4}[a-zA-Z]$")]
        [Required(ErrorMessage = "El campo no debe estar vacio")]
        public string? NumeroGuia { get; set; }
        [Required(ErrorMessage = "El campo no debe estar vacio")]
        public string? TipoProducto { get; set; }
        [Required(ErrorMessage = "El campo no debe estar vacio")]
        public decimal CantidadProducto { get; set; }
        [Required(ErrorMessage = "El campo no debe estar vacio")]
        public DateTime FechaRegistro { get; set; }
        [Required(ErrorMessage = "El campo no debe estar vacio")]
        public DateTime FechaEntrega { get; set; }
        [Required(ErrorMessage = "El campo no debe estar vacio")]
        public decimal PrecioEnvio { get; set; }
        [Required(ErrorMessage = "El campo no debe estar vacio")]
        public decimal Descuento { get; set; }
        [Required(ErrorMessage = "El campo no debe estar vacio")]
        public string? DocumentoCliente { get; set; }
        [Required(ErrorMessage = "El campo no debe estar vacio")]
        public string? PlacaONumFlota { get; set; }
        [Required(ErrorMessage = "El campo no debe estar vacio")]
        public string? PuertoOBodega { get; set; }



    }
}
