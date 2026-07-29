using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Shared.Models.Clinica
{
    [Table("Diagnostico", Schema = "dbo")]
    public partial class Diagnostico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("idDiagnostico")]
        public int IdDiagnostico { get; set; }

        [Column("estado")]
        public bool? Estado { get; set; }

        [Column("fechaEmision")]
        public DateTime? FechaEmision { get; set; }

        [Column("observacion")]
        public string Observacion { get; set; }

        [Column("idHistoriaClinica")]
        [Required]
        public int IdHistoriaClinica { get; set; }

        public HistoriaClinica HistoriaClinica { get; set; }
    }
}