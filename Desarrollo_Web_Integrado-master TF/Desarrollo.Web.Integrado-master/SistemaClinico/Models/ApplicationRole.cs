using System.Text.Json.Serialization;

namespace SistemaClinico.Models
{
    public partial class ApplicationRole //: IdentityRole
    {
        [JsonIgnore]
        public ICollection<ApplicationUser> Users { get; set; }
    }
}
