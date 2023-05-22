using System.ComponentModel.DataAnnotations;

namespace GestionLogisticaApiR.Models
{
    public class Cliente
    {
        [Required( ErrorMessage ="El campo no debe estar vacio")]
        public string? Documento { get; set; }
        [Required(ErrorMessage = "El campo no debe estar vacio")]
        public string? Nombres { get; set; }
        [Required(ErrorMessage = "El campo no debe estar vacio")]
        public string? Apellidos { get; set; }
        [Required(ErrorMessage = "El campo no debe estar vacio")]
        public string? Direccion { get; set; }

        [RegularExpression("^[\\w.-]+@[a-zA-Z_-]+?\\.[a-zA-Z]{2,3}$")]
        [Required(ErrorMessage = "El campo no debe estar vacio")]
        public string? CorreoElectronico { get; set; }
    }
}
