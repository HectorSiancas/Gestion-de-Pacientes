using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Shared.Models.Clinica
{
    [Table("Hora", Schema = "dbo")]
    public partial class Hora
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("idHora")]
        public int IdHora { get; set; }

        [Column("hora")]
        [JsonPropertyName("hora")]
        public string Hora1 { get; set; }

        public ICollection<HorarioAtencion> HorarioAtencions { get; set; }
    }
}