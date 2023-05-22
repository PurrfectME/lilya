using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models
{
    public class Company
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 2)]
        [Required(ErrorMessage = "Введите имя")]
        [DisplayName("Название")]
        public string Name { get; set; }

        //[StringLength(10, MinimumLength = 10)]
        [Required(ErrorMessage = "Введите ИНН/УНП")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Введите 10 цифр")]
        [DisplayName("ИНН/УНП")]
        public string InnUnp { get; set; }

        //[Range(1, 3)]
        [Required(ErrorMessage = "Введите тип компании(1 - учебное зав., 2 - медицина, 3 - производство")]
        [DisplayName("ID бизнеса")]
        public int BusinessId { get; set; }

        [StringLength(200, MinimumLength = 3)]
        [DisplayName("Адрес")]
        [Required(ErrorMessage = "Введите адрес")]
        public string Address { get; set; }

        [StringLength(200, MinimumLength = 3)]
        [DisplayName("Город")]
        [Required(ErrorMessage = "Введите город")]
        public string City { get; set; }

        //[Range(1, 3)]
        [Required(ErrorMessage = "ID юзера")]
        [DisplayName("ID юзера")]
        public int UserId { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Дата создания")]
        //[Range(typeof(DateTime), "1900-01-01", "2010-01-01" ,
        //ErrorMessage = "Value for {0} must be between {1} and {2}")]
        //[CustomDateRange(ErrorMessage = "wrong")]
        //[Date(ErrorMessage = "wrong")]
        public DateTime CreationDate { get; set; }

        public List<Order> Orders { get; set; }

        public int IsDeleted { get; set; }
    }
}
