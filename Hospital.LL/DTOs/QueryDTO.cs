using System;
using System.ComponentModel.DataAnnotations;

namespace Hospital.LL.DTOs
{
    public class QueryDTO
    {
        [Required(ErrorMessage = "The field id is required")]
        public int id { get; set; }

        [Required(ErrorMessage = "The field id safe required")]
        public int id_safe { get; set; }

        [Required(ErrorMessage = "The field id employee is required")]
        public int id_employee { get; set; }

        [Required(ErrorMessage = "The field date is required")]
        public DateTime date { get; set; }

        [Required(ErrorMessage = "The field treatment is required")]
        public string treatment { get; set; }

    }
}
