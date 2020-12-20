using Hospital.BL.Models;
using Hospital.LL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.LL.Services.Implements
{
    public class DoctorServices : GenericService<Doctor>, IDoctorServices
    {
        public DoctorServices(IGenericRepository<Doctor> genericRepository) : base(genericRepository)
        {
        }
    }
}
