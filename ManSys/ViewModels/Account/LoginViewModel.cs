using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ManSys.ViewModels
{
    public class LoginViewModel
    {
        public InputModel? Input { get; set; }
        public class InputModel
        {
            [Required]
            [Display(Name = "Email")]
            public string? Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Пароль")]
            public string? Password { get; set; }

            [Display(Name = "Запомнить меня")]
            public bool RememberMe { get; set; }
        }
            public string? ReturnUrl { get; set; }
    }
}