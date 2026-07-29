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
    public class HorarioAtencionDTO
    {
        public int IdHorarioAtencion { get; set; }

        public bool? Estado { get; set; }

        public DateTime? Fecha { get; set; }

        public DateTime? FechaFin { get; set; }

        public int? IdDiaSemana { get; set; }

        public DiaSemana DiaSemana { get; set; }


        public int IdHoraInicio { get; set; }

        public Hora HoraInicio { get; set; }


        public int IdMedico { get; set; }

        public MedicoDTO Medico { get; set; }
    }
}
