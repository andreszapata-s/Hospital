using System;
using System.ComponentModel.DataAnnotations;

namespace Hospital.LL.DTOs
{
    public class PatientDTO
    {
        [Required(ErrorMessage = "The field id safe is required")]
        public int id_safe { get; set; }

        [Required(ErrorMessage = "The field name is required")]
        [StringLength(50)]
        public string name { get; set; }

        [Required(ErrorMessage = "The field birthday is required")]
        public DateTime birthday { get; set; }

        [Required(ErrorMessage = "The field telephone is required")]
        public int telephone { get; set; }
    }
}
