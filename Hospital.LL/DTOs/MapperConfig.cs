using AutoMapper;
using Hospital.BL.Models;

namespace Hospital.LL.DTOs
{
    public class MapperConfig
    {
        public static MapperConfiguration MapperConfiguration()
        {
            return new MapperConfiguration(x =>
            {
                x.CreateMap<Doctor, DoctorDTO>();
                x.CreateMap<DoctorDTO, Doctor>();
                x.CreateMap<Patient, PatientDTO>();
                x.CreateMap<PatientDTO, Patient>();
                x.CreateMap<Query, QueryDTO>();
                x.CreateMap<QueryDTO, Query>();
            });
        }
    }
}
