using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Shared.Models.Clinica
{
    [Table("Menu", Schema = "dbo")]
    public partial class Menu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("idMenu")]
        public int IdMenu { get; set; }

        [Column("estado")]
        public bool? Estado { get; set; }

        [Column("isSubmenu")]
        public bool? IsSubmenu { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; }

        [Column("orden")]
        public int? Orden { get; set; }

        [Column("show")]
        public bool? Show { get; set; }

        [Column("url")]
        public string Url { get; set; }

        [Column("idMenuParent")]
        public int? IdMenuParent { get; set; }

        public Menu Menu1 { get; set; }

        public ICollection<Menu> Menus1 { get; set; }

        public ICollection<Permiso> Permisos { get; set; }
    }
}