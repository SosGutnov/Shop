using Shop.Areas.Admin.Models;
using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class UserAccount
    {
        private static int _id;

        public int Id { get; set; }

        [Required(ErrorMessage = "Не указано имя")]
        [StringLength(25, MinimumLength = 4, ErrorMessage = "Имя должно содержать от 4 до 25 символов")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        public string Password { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public Role Role { get; set; }

        public UserAccount()
        {
            Id = _id;
            _id += 1;
            Role = new Role() { Name = "user" };
        }
    }
}
