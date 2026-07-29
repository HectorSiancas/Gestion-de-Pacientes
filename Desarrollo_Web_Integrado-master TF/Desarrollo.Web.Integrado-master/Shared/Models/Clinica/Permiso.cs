using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Shared.Models.Clinica
{
    [Table("Permisos", Schema = "dbo")]
    public partial class Permiso
    {
        [Column("estado")]
        public bool? Estado { get; set; }

        [Key]
        [Column("idMenu")]
        [Required]
        public int IdMenu { get; set; }

        public Menu Menu { get; set; }

        [Key]
        [Column("idEmpleado")]
        [Required]
        public int IdEmpleado { get; set; }

        public Empleado Empleado { get; set; }
    }
}