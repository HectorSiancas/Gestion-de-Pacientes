using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Shared.Models.Clinica
{
    [Table("Empleado", Schema = "dbo")]
    public partial class Empleado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("idEmpleado")]

        public int IdEmpleado { get; set; }

        [Column("apMaterno")]
        public string ApMaterno { get; set; }

        [Column("apPaterno")]
        public string ApPaterno { get; set; }

        [Column("clave")]
        public string Clave { get; set; }

        [Column("estado")]
        public bool? Estado { get; set; }

        [Column("imagen")]
        public string Imagen { get; set; }

        [Column("nombres")]
        public string Nombres { get; set; }

        [Column("nroDocumento")]
        public string NroDocumento { get; set; }

        [Column("usuario")]
        public string Usuario { get; set; }

        [Column("idTipoEmpleado")]
        [Required]
        public int IdTipoEmpleado { get; set; }

        public TipoEmpleado TipoEmpleado { get; set; }

        public ICollection<Medico> Medicos { get; set; }

        public ICollection<Permiso> Permisos { get; set; }
    }
}