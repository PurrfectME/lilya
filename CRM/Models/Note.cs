using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models
{
    public class Note
    {
        public int Id { get; set; }

        [StringLength(500)]
        [Required(ErrorMessage = "Введите контент")]
        [DisplayName("Контент")]
        public string Content { get; set; }

        [Required(ErrorMessage = "Введите ID бизнеса")]
        [DisplayName("ID бизнеса")]
        public int CompanyId { get; set; }

        [Required(ErrorMessage = "Введите ID юзера")]
        [DisplayName("ID юзера")]
        public int UserId { get; set; }

        public int IsDeleted { get; set; }
    }
}
