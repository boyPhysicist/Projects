using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Task5.Models
{
    public class ManagerView
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Введите имя менеджера")]
        [Display(Name = "Имя менеджера")]
        [StringLength(50, ErrorMessage = "Значение {0} должно содержать символов не менее: {2}.", MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        public string Email { get; set; }
    }
}