using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class Login
    {
        [Required(ErrorMessage ="Не указано имя")]
        [StringLength(25, MinimumLength = 4, ErrorMessage ="Имя должно содержать от 4 до 25 символов")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        public string Password { get; set; }
    }
}
