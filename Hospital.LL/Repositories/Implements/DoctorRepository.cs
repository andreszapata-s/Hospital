using Hospital.BL.Data;
using Hospital.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.LL.Repositories.Implements
{
    public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(HospitalContext hospitalContext) : base(hospitalContext)
        {
        }
    }
}
