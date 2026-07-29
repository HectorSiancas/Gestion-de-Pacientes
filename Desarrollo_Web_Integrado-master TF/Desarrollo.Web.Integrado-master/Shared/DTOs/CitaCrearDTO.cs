using Shared.Models.Clinica;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public class CitaCrearDTO
    {
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
