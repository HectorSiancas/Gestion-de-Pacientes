using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public class HoraCrearDTO
    {
        //[Column("hora")]
        //[JsonPropertyName("hora")]
        public string Hora { get; set; }
    }
}
