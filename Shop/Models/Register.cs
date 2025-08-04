using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class Register
    {
        [Required(ErrorMessage = "Не указано имя")]
        [StringLength(25, MinimumLength = 4, ErrorMessage = "Имя должно содержать от 4 до 25 символов")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Не указан повторный пароль")]
        [Compare("Password", ErrorMessage ="Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
    }
}
