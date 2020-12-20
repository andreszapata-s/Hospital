using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.BL.Models
{
    [Table("Patient", Schema = "dbo")]
    public class Patient
    {
        [Key]
        public int id_safe { get; set; }

        public string name { get; set; }

        public DateTime birthday { get; set; }

        public int telephone { get; set; }

        public ICollection<Query> queries { get; set; }

    }
}
