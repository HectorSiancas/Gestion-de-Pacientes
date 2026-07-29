using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Shared.Models.Clinica;

namespace Shared.DTOs
{
    public class EmpleadoCreateDTO
    {
        //[Column("idEmpleado")]
        //[Required(ErrorMessage = "El campo {0} es obligatorio.")]
        //public int IdEmpleado { get; set; }

        [Column("apMaterno")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string ApMaterno { get; set; }

        [Column("apPaterno")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string ApPaterno { get; set; }

        [Column("clave")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Clave { get; set; }

        [Column("estado")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public bool? Estado { get; set; }

        [Column("imagen")]
        //[Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Imagen { get; set; }

        [Column("nombres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Nombres { get; set; }

        [Column("nroDocumento")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string NroDocumento { get; set; }

        [Column("usuario")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Usuario { get; set; }

        [Column("idTipoEmpleado")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int IdTipoEmpleado { get; set; }

        public TipoEmpleado TipoEmpleado { get; set; }
    }
}
