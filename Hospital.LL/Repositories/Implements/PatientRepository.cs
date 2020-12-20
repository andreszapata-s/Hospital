using Hospital.BL.Data;
using Hospital.BL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.LL.Repositories.Implements
{
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {
        public PatientRepository(HospitalContext hospitalContext) : base(hospitalContext)
        {
        }
    }
}
