using AutoMapper;
using Hospital.BL.Data;
using Hospital.BL.Models;
using Hospital.LL.DTOs;
using Hospital.LL.Repositories.Implements;
using Hospital.LL.Services.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace Hospital.API.Controllers
{
    public class PatientsController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly PatientServices patientService = new PatientServices(new PatientRepository(HospitalContext.Create()));

        public PatientsController()
        {
            _mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            IEnumerable<Patient> patients = await patientService.GetAll();
            IEnumerable<PatientDTO> patientDTO = patients.Select(x => _mapper.Map<PatientDTO>(x));
            return Ok(patientDTO);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetById(int id)
        {
            Patient patient = await patientService.GetById(id);

            if (patient == null)
                return NotFound();


            PatientDTO courseDTO = _mapper.Map<PatientDTO>(patient);

            return Ok(courseDTO);
        }


        [HttpPost]
        public async Task<IHttpActionResult> Post(PatientDTO patientDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Patient patient = _mapper.Map<Patient>(patientDTO);
                patient = await patientService.Insert(patient);

                return Ok(patient);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        public async Task<IHttpActionResult> Put(PatientDTO patientDTO, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (patientDTO.id_safe != id)
                return BadRequest();

            Patient patient = await patientService.GetById(id);

            if (patient == null)
                return NotFound();

            try
            {
                Patient _patient = _mapper.Map<Patient>(patientDTO);
                _patient = await patientService.Update(_patient);
                return Ok(_patient);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok();
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            Patient patient = await patientService.GetById(id);

            if (patient == null)
                return NotFound();

            await patientService.Delete(id);
            PatientDTO courseDTO = _mapper.Map<PatientDTO>(patient);

            return Ok();
        }
    }
}