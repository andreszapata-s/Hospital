using Hospital.BL.Models;
using System.Data.Entity;

namespace Hospital.BL.Data
{
    public class HospitalContext : DbContext
    {
        public HospitalContext() : base("HospitalContext")
        {
        }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Query> Queries { get; set; }
        public static HospitalContext Create()
        {
            return new HospitalContext();
        }
    }
}
