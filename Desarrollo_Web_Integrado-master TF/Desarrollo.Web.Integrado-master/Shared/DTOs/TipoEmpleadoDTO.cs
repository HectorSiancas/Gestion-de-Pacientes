using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Shared.DTOs
{
    public class TipoEmpleadoDTO
    {
        [Column("descripcion")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Descripcion { get; set; }

        [Column("estado")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public bool? Estado { get; set; }
    }
}
