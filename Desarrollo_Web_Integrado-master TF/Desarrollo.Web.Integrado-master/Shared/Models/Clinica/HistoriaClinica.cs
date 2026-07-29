using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Shared.Models.Clinica
{
    [Table("HistoriaClinica", Schema = "dbo")]
    public partial class HistoriaClinica
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("idHistoriaClinica")]
        public int IdHistoriaClinica { get; set; }

        [Column("estado")]
        public bool? Estado { get; set; }

        [Column("fechaApertura")]
        public DateTime? FechaApertura { get; set; }

        [Column("idPaciente")]
        public int? IdPaciente { get; set; }

        public Paciente Paciente { get; set; }

        public ICollection<Diagnostico> Diagnosticos { get; set; }
    }
}