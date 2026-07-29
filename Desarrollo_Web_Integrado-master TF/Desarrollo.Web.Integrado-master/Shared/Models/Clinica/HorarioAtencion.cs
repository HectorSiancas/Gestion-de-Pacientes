using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Shared.Models.Clinica
{
    [Table("HorarioAtencion", Schema = "dbo")]
    public partial class HorarioAtencion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("idHorarioAtencion")]
        public int IdHorarioAtencion { get; set; }

        [Column("estado")]
        public bool? Estado { get; set; }

        [Column("fecha")]
        public DateTime? Fecha { get; set; }

        [Column("fechaFin")]
        public DateTime? FechaFin { get; set; }

        [Column("idDiaSemana")]
        public int? IdDiaSemana { get; set; }

        public DiaSemana DiaSemana { get; set; }

        [Column("idHoraInicio")]
        [Required]
        public int IdHoraInicio { get; set; }

        public Hora HoraInicio { get; set; }

        [Column("idMedico")]
        [Required]
        public int IdMedico { get; set; }

        public Medico Medico { get; set; }

        public ICollection<Citum> Cita { get; set; }

        public string MyHoraInicio => $"{DiaSemana?.NombreDiaSemana} - {HoraInicio?.Hora1}";
    }
}