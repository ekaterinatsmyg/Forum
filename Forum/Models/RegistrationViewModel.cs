using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Forum.Models
{
    public class RegistrationViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Введите e-mail")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Неккоректный e-mail")]
        public string Email { get; set; }

        [Display(Name = "Логин")]
        [Required(ErrorMessage = "Введите логин")]
        [RegularExpression(@"[A-Za-z0-9._%+-]*", ErrorMessage = "Некорректный логин")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [StringLength(100, ErrorMessage = "Пароль не может содержать меньше, чем {2} символом", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Введите пароль снова")]
        [DataType(DataType.Password)]
        [Display(Name = "Повторите пароль")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
         
        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }

        [Display(Name = "Имя")]
        public string Name { get; set; }
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }
       
    }
}