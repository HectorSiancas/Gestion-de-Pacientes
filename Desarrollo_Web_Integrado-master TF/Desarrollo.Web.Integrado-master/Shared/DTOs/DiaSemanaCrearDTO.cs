using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public class DiaSemanaCrearDTO
    {
        [Column("nombreDiaSemana")]
        public string NombreDiaSemana { get; set; }
    }
}
