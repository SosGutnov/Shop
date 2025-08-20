using System.ComponentModel.DataAnnotations;

namespace ShopDb.Models
{
    public class UserDeliveryInfo
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Addres { get; set; }
    }
}
