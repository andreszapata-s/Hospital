using System.ComponentModel.DataAnnotations;

namespace Hospital.LL.DTOs
{
    public class DoctorDTO
    {
        [Required(ErrorMessage = "The field id employee is required")]
        public int id_employee { get; set; }

        [Required(ErrorMessage = "The field name is required")]
        [StringLength(50)]
        public string name { get; set; }

        [Required(ErrorMessage = "The field clinic is required")]
        public string clinic { get; set; }

    }
}
