using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Shared.Models.Clinica
{
    //[Table("Paciente", Schema = "dbo")]
    public partial class Paciente
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("idPaciente")]
        public int IdPaciente { get; set; }

        [Column("apMaterno")]
        public string ApMaterno { get; set; }

        [Column("apPaterno")]
        public string ApPaterno { get; set; }

        [Column("direccion")]
        public string Direccion { get; set; }

        [Column("edad")]
        public int? Edad { get; set; }

        [Column("estado")]
        public bool? Estado { get; set; }

        [Column("imagen")]
        public string Imagen { get; set; }

        [Column("nombres")]
        public string Nombres { get; set; }

        [Column("nroDocumento")]
        public string NroDocumento { get; set; }

        [Column("sexo")]
        public string Sexo { get; set; }

        [Column("telefono")]
        public string Telefono { get; set; }

        public ICollection<Citum> Cita { get; set; }

        public ICollection<HistoriaClinica> HistoriaClinicas { get; set; }

        [NotMapped]
        public string NombresApellidos =>  $"{Nombres} {ApPaterno}";

    }
}