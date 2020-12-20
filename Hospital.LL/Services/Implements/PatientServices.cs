using Hospital.BL.Models;
using Hospital.LL.Repositories;

namespace Hospital.LL.Services.Implements
{
    public class PatientServices : GenericService<Patient>, IPatientServices
    {
        public PatientServices(IGenericRepository<Patient> genericRepository) : base(genericRepository)
        {
        }
    }
}
