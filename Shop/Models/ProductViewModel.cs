using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;

namespace Shop.Models
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Cost { get; set; }

        [Required]
        public string Description { get; set; }

        
        public string? ImagePath { get; set; }


        public override string ToString()
        {
            return $"{Id}\n{Name}\n{Cost}";
        }
    }
}
