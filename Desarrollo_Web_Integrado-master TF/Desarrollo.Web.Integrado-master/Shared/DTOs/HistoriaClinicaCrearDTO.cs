using Shared.Models.Clinica;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public class HistoriaClinicaCrearDTO
    {
        [Column("estado")]
        public bool? Estado { get; set; }

        [Column("fechaApertura")]
        public DateTime? FechaApertura { get; set; }

        [Column("idPaciente")]
        public int? IdPaciente { get; set; }
        public Paciente Paciente { get; set; }
    }
}
