using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;

namespace Shop.Models
{
    public class Product
    {
        private static int _id;

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Cost { get; set; }

        [Required]
        public string Description { get; set; }

        
        public string ImagePath { get; set; }

        public string InFollow { get; set; }

        public Product()
        {
            ImagePath = "/images/jinx.png";
            InFollow = "";
            Id = _id;
            _id += 1;
        }
        public Product(string name, decimal cost, string description, string imagepath):this()
        {
            
            Name = name;
            Cost = cost;
            Description = description;
            ImagePath = imagepath;
            
            InFollow = "none";
        }

        public override string ToString()
        {
            return $"{Id}\n{Name}\n{Cost}";
        }
    }
}
