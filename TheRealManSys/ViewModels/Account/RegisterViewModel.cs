using System.ComponentModel.DataAnnotations;

namespace TheRealManSys.ViewModels
{
    public class RegisterViewModel
    {

        public InputModel Input { get; set; }
        public static bool FirstRegister { get; set; }
        public class InputModel
        {
            [Required]
            [Display(Name = "Email")]
            [DataType(DataType.EmailAddress)]
            public string Email { get; set; }

            [Required]
            [Display(Name = "Имя")]
            public string SurName { get; set; }

            [Required]
            [Display(Name = "Фамилия")]
            public string Name { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Пароль")]
            public string Password { get; set; }

            [Required]
            [DataType(DataType.PhoneNumber)]
            [Display(Name = "Номер телефона")]
            public string PhoneNumber { get; set; }

        }
    }
}