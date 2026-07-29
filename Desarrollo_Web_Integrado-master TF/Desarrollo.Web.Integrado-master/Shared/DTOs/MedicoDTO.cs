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
    public class MedicoDTO
    {
        public int IdMedico { get; set; }

        public bool? Estado { get; set; }

        public int IdEmpleado { get; set; }

        public Empleado Empleado { get; set; }

        public int IdEspecialidad { get; set; }

        public Especialidad Especialidad { get; set; }

        public ICollection<HorarioAtencion> HorarioAtencions { get; set; }

        public string NombresApellidos => Empleado == null ? string.Empty : $"{Empleado.Nombres} {Empleado.ApPaterno}";
    }
}
