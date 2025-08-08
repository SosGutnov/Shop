using System.ComponentModel.DataAnnotations;

namespace Shop.Areas.Admin.Models
{
    public class Role
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public Role()
        {
            Id = Guid.NewGuid();
        }
    }
}
