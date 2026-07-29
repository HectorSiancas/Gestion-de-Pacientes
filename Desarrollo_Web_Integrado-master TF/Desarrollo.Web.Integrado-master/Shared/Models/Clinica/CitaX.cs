using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Shared.Models.Clinica
{
    [Table("Cita", Schema = "dbo")]
    public partial class CitaX
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("idCita")]
        public int IdCita { get; set; }

        [Column("estado")]
        public string Estado { get; set; }

        [Column("fechaReserva")]
        public DateTime? FechaReserva { get; set; }

        [Column("hora")]
        public string Hora { get; set; }

        [Column("observacion")]
        public string Observacion { get; set; }

        [Column("idHorarioAtencion")]
        public int? IdHorarioAtencion { get; set; }

        public HorarioAtencion HorarioAtencion { get; set; }

        [Column("idPaciente")]
        [Required]
        public int IdPaciente { get; set; }

        public Paciente Paciente { get; set; }
    }
}