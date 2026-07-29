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
    public class HorarioAtencionCrearDTO
    {
        [Required]
        [Column("estado")]
        public bool? Estado { get; set; }

        [Required]
        [Column("fecha")]
        public DateTime? Fecha { get; set; }

        [Column("fechaFin")]
        public DateTime? FechaFin { get; set; }

        [Required]
        [Column("idDiaSemana")]
        public int? IdDiaSemana { get; set; }

        public DiaSemana DiaSemana { get; set; }

        [Column("idHoraInicio")]
        [Required]
        public int IdHoraInicio { get; set; }

        //public HoraCrearDTO Hora { get; set; }
        public Hora HoraInicio { get; set; }


        [Column("idMedico")]
        [Required]
        public int IdMedico { get; set; }

        public Medico Medico { get; set; }
    }
}
