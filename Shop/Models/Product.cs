using static System.Net.Mime.MediaTypeNames;

namespace Shop.Models
{
    public class Product
    {
        private static int _id;

        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Cost { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }

        public string InFollow { get; set; }

        public Product(string name, decimal cost, string description, string imagepath)
        {
            Id = _id;
            Name = name;
            Cost = cost;
            Description = description;
            ImagePath = imagepath;
            _id += 1;
            InFollow = "none";
        }

        public override string ToString()
        {
            return $"{Id}\n{Name}\n{Cost}";
        }
    }
}
