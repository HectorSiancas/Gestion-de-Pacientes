using Shared.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Shared.DTOs
{
    public class PacienteCreateDTO
    {
        [Column("apMaterno")]
        [Required(ErrorMessage = "El apellido materno es obligatorio.")]
        public string ApMaterno { get; set; }

        [Column("apPaterno")]
        [Required(ErrorMessage = "El apellido paterno es obligatorio.")]
        public string ApPaterno { get; set; }

        [Column("direccion")]
        //[Required(ErrorMessage = "La dirección es obligatoria.")]
        [Required(ErrorMessage = "El correo es obligatorio")]
        [EmailAddress(ErrorMessage = "Correo no válido")]
        public string Direccion { get; set; }

        [Column("edad")]
        [Required, Range(18, 120, ErrorMessage = "La edad debe estar entre 18 y 120 años.")]
        public int? Edad { get; set; } = 18;

        [Column("estado")]
        [Required(ErrorMessage = "El estado es obligatorio.")]
        public bool? Estado { get; set; }

        [Column("imagen")]
        public string Imagen { get; set; }

        [Column("nombres")]
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Nombres { get; set; }

        [Column("nroDocumento")]
        [Required(ErrorMessage = "El número de documento es obligatorio.")]
        public string NroDocumento { get; set; }

        [Column("sexo")]
        [Required(ErrorMessage = "El sexo es obligatorio.")]
        public string Sexo { get; set; }

        [Column("telefono")]
        [Required(ErrorMessage = "El teléfono es obligatorio.")]
        public string Telefono { get; set; }

        //// Propiedad auxiliar para trabajar como Enum
        //[JsonIgnore] // Opcional: si estás serializando, evita enviar esto
        //public SexoEnum SexoEnum
        //{
        //    get
        //    {
        //        return Enum.TryParse<SexoEnum>(Sexo, out var result) ? result : SexoEnum.M;
        //    }
        //    set
        //    {
        //        Sexo = value.ToString(); // Sincroniza el string con el Enum
        //    }
        //}

    }
}
