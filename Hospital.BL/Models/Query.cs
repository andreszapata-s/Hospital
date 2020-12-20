using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.BL.Models
{
    [Table("Query", Schema = "dbo")]
    public class Query
    {
        [Key]
        public int id { get; set; }

        [ForeignKey("patient")]
        public int id_safe { get; set; }

        [ForeignKey("doctor")]
        public int id_employee { get; set; }

        public DateTime date { get; set; }

        public string treatment { get; set; }

        public Doctor doctor { get; set; }

        public Patient patient { get; set; }
    }
}
