using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Shared.Models.Clinica
{
    [Table("Especialidad", Schema = "dbo")]
    public partial class Especialidad
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("idEspecialidad")]
        public int IdEspecialidad { get; set; }

        [Column("descripcion")]
        public string Descripcion { get; set; }

        [Column("estado")]
        public bool? Estado { get; set; }

        public ICollection<Medico> Medicos { get; set; }
    }
}