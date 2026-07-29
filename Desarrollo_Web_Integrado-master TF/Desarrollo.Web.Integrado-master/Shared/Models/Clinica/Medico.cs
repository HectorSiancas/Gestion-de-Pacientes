using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Shared.Models.Clinica
{
    [Table("Medico", Schema = "dbo")]
    public partial class Medico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("idMedico")]
        public int IdMedico { get; set; }

        [Column("estado")]
        public bool? Estado { get; set; }

        [Column("idEmpleado")]
        [Required]
        public int IdEmpleado { get; set; }

        public Empleado Empleado { get; set; }

        [Column("idEspecialidad")]
        [Required]
        public int IdEspecialidad { get; set; }

        public Especialidad Especialidad { get; set; }

        public ICollection<HorarioAtencion> HorarioAtencions { get; set; }

        [NotMapped]
        public string NombresApellidos => Empleado == null ? string.Empty : $"{Empleado.Nombres} {Empleado.ApPaterno}";
    }
}