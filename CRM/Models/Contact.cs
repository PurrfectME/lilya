using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 2)]
        [Required(ErrorMessage = "Введите имя")]
        [DisplayName("Имя")]
        public string Name { get; set; }

        [StringLength(60, MinimumLength = 2)]
        [Required(ErrorMessage = "Введите фамилию")]
        [DisplayName("Фамилия")]
        public string Surname { get; set; }

        [RegularExpression(@"^(\d{12})$", ErrorMessage = "Введите номер телефона")]
        [Required(ErrorMessage = "Введите номер телефона")]
        [DisplayName("Телефон")]
        public string Phone { get; set; }

        [RegularExpression(@"^(([^<>()[\]\\.,;:\s@""]+(\.[^<>()[\]\\.,;:\s@""]+)*)|("".+""))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$", ErrorMessage = "Некорреткно")]
        [Required(ErrorMessage = "Введите почту")]
        [DisplayName("почта")]
        public string Email { get; set; }

        [StringLength(60, MinimumLength = 2)]
        [Required(ErrorMessage = "Введите позицию")]
        [DisplayName("Позиция")]
        public string Position { get; set; }

        [Required(ErrorMessage = "Введите ID бизнеса")]
        [DisplayName("Бизнес")]
        public int CompanyId { get; set; }

        [Required(ErrorMessage = "Введите ID юзера")]
        [DisplayName("ID")]
        public int UserId { get; set; }

        public int IsDeleted { get; set; }
    }
}
