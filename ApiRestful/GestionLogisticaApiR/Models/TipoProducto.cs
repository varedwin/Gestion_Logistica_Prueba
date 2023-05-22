using System.ComponentModel.DataAnnotations;

namespace GestionLogisticaApiR.Models
{
    public class TipoProducto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo no debe estar vacio")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "El campo no debe estar vacio")]
        public int IdLogistica { get; set; }
    }
}
