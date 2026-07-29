using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public class EspecialidadCrearDTO
    {
        [Column("descripcion")]
        public string Descripcion { get; set; }

        [Column("estado")]
        public bool? Estado { get; set; }
    }
}
