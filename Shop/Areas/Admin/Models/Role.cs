using System.ComponentModel.DataAnnotations;

namespace Shop.Areas.Admin.Models
{
    public class Role
    {
        [Required]
        public string Name { get; set; }
    }
}
