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
    public class MedicoCrearDTO
    {
        [Column("estado")]
        public bool? Estado { get; set; }

        [Column("idEmpleado")]
        [Required]
        public int IdEmpleado { get; set; }

        public Empleado Empleado { get; set; }

        [Column("idEspecialidad")]
        [Required]
        public int IdEspecialidad { get; set; }
        public Especialidad Especialidad { get; set; }

    }
}
