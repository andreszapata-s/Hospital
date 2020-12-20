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
using System.Web.Http.Description;

namespace Hospital.API.Controllers
{
    public class DoctorsController : ApiController
    {
        private IMapper _mapper;
        private readonly DoctorServices doctorServices = new DoctorServices(new DoctorRepository(HospitalContext.Create()));

        public DoctorsController()
        {
            _mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }

        /// <summary>
        /// This method gets a doctor for the id.
        /// </summary>
        /// <returns> List of doctors for a query </returns>
        /// <Response code = "200"> Ok is the successful response in returning requested objects </Response>
        [HttpGet]
        public async Task<IHttpActionResult> GetById(int id)
        {
            Doctor doctor = await doctorServices.GetById(id);

            if (doctor == null)
            {
                return NotFound();
            }

            DoctorDTO doctorDTO = _mapper.Map<DoctorDTO>(doctor);

            return Ok(doctorDTO);
        }

        /// <summary>
        /// This method gets all the doctors.
        /// </summary>
        /// <returns> A list of doctors. </returns>
        /// <Response code = "200"> Ok is the successful response in returning requested objects </Response>
        /// <Response code = "404"> Not Found, the requested resource does not exist. </Response>
        [HttpGet]
        [ResponseType(typeof(IEnumerable<DoctorDTO>))]
        public async Task<IHttpActionResult> GetAll()
        {
            IEnumerable<Doctor> doctors = await doctorServices.GetAll();
            IEnumerable<DoctorDTO> doctorsDTO = doctors.Select(x => _mapper.Map<DoctorDTO>(x));
            return Ok(doctorsDTO);
        }

        /// <summary>
        /// This method does the insertion of a doctor.
        /// </summary>
        /// <param name = "doctorDTO"> A query with  employee_id and others </param>
        /// <returns> The course that was previously inserted. </returns>
        [HttpPost]
        public async Task<IHttpActionResult> Post(DoctorDTO doctorDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                Doctor doctors = _mapper.Map<Doctor>(doctorDTO);
                doctors = await doctorServices.Insert(doctors);

                return Ok(doctors);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        /// <summary>
        /// This method updates a doctor.
        /// </summary>
        /// <param name = "doctorDTO"> </param>
        /// <param name = "id"> </param>
        /// <returns> </returns>[HttpPut]
        public async Task<IHttpActionResult> Put(DoctorDTO doctorsDTO, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (doctorsDTO.id_employee != id)
                return BadRequest(ModelState);

            Doctor doctors = await doctorServices.GetById(id);

            if (doctors == null)
                return null;

            try
            {
                Doctor _doctors = _mapper.Map<Doctor>(doctorsDTO);
                _doctors = await doctorServices.Update(_doctors);

                return Ok(_doctors);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        /// <summary>
        /// This method does the elimination of a doctor by means of an id.
        /// </summary>
        /// <param name = "doctorDTO"> </param>
        /// <param name = "id"> </param>
        /// <returns> </returns>
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            Doctor doctors = await doctorServices.GetById(id);

            if (doctors == null)
                return NotFound();
            try
            {
                await doctorServices.Delete(id);
                DoctorDTO doctorsDTO = _mapper.Map<DoctorDTO>(doctors);

                return Ok(doctorsDTO);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }
    }
}