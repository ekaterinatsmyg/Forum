using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Forum.Models
{
    public class SignInViewModel
    {
        [Required(ErrorMessage = "Введите логин")]
        [Display(Name = "Логин")]
        [RegularExpression(@"[A-Za-z0-9._%+-]*", ErrorMessage = "Неверный логин")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name = "Запомнить меня?")]
        public bool RememberMe { get; set; }
    }
}