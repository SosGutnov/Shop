using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class UserDeliveryInfo
    {
        [Required(ErrorMessage = "Не указано имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указан телефон")]
        [StringLength(11, MinimumLength = 11, ErrorMessage ="Неправильный номер телефона")]
        public string Phone { get; set; }

        [EmailAddress(ErrorMessage ="Введите валидный email")]
        public string Addres { get; set; }
    }
}
