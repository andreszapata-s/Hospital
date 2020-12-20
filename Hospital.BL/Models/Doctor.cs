using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.BL.Models
{
    [Table("Doctor", Schema = "dbo")]
    public class Doctor
    {
        [Key]
        public int id_employee { get; set; }

        public string name { get; set; }

        public string clinic { get; set; }

        public ICollection<Query> Queries { get; set; }

    }
}
