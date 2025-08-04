using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class Role
    {
        [Required]
        public string Name { get; set; }
    }
}
