using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Shared.Models.Clinica
{
    [Table("DiaSemana", Schema = "dbo")]
    public partial class DiaSemana
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("idDiaSemana")]
        public int IdDiaSemana { get; set; }

        [Column("nombreDiaSemana")]
        public string NombreDiaSemana { get; set; }

        public ICollection<HorarioAtencion> HorarioAtencions { get; set; }
    }
}