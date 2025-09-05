using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class ChangePassword
    {
        public string UserId { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Не указан повторный пароль")]
        [Compare("Password", ErrorMessage ="Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
    }
}
