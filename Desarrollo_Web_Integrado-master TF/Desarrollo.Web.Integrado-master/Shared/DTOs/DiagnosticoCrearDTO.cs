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
    public class DiagnosticoCrearDTO
    {
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
