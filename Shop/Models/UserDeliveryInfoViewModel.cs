using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class UserDeliveryInfoViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Не указано имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указан телефон")]
        [StringLength(11, MinimumLength = 11, ErrorMessage ="Неправильный номер телефона")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Не указан адрес")]
        public string Addres { get; set; }
    }
}
