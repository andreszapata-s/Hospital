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
    public class QueriesController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly QueryServices queryServices = new QueryServices(new QueryRepository(HospitalContext.Create()));

        public QueriesController()
        {
            _mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }

        /// <summary>
        /// This method gets a query for the id.
        /// </summary>
        /// <returns> List of consultations for a patient </returns>
        /// <Response code = "200"> Ok is the successful response in returning requested objects </Response>
        [HttpGet]
        public async Task<IHttpActionResult> GetById(int id)
        {
            Query query = await queryServices.GetById(id);

            if (query == null)
            {
                return NotFound();
            }

            QueryDTO queryDTO = _mapper.Map<QueryDTO>(query);

            return Ok(queryDTO);
        }

        /// <summary>
        /// This method gets all the queries.
        /// </summary>
        /// <returns> A list of queries. </returns>
        /// <Response code = "200"> Ok is the successful response in returning requested objects </Response>
        /// <Response code = "404"> Not Found, the requested resource does not exist. </Response>
        [HttpGet]
        [ResponseType(typeof(IEnumerable<PatientDTO>))]
        public async Task<IHttpActionResult> GetAll()
        {
            IEnumerable<Query> queries = await queryServices.GetAll();
            IEnumerable<QueryDTO> queryDTO = queries.Select(x => _mapper.Map<QueryDTO>(x));
            return Ok(queryDTO);
        }

        /// <summary>
        /// This method does the insertion of a query.
        /// </summary>
        /// <param name = "queryDTO"> A query with insurance_id, employee_id, date and title. </param>
        /// <returns> The course that was previously inserted. </returns>
        [HttpPost]
        public async Task<IHttpActionResult> Post(QueryDTO queryDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Query query = _mapper.Map<Query>(queryDTO);
                query = await queryServices.Insert(query);

                return Ok(query);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }


        /// <summary>
        /// This method updates a query.
        /// </summary>
        /// <param name = "queryDTO"> </param>
        /// <param name = "id"> </param>
        /// <returns> </returns>
        [HttpPut]
        public async Task<IHttpActionResult> Put(QueryDTO queryDTO, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (queryDTO.id != id)
            {
                return BadRequest(ModelState);
            }

            Query query = await queryServices.GetById(id);

            if (query == null)
            {
                return null;
            }

            try
            {
                Query _query = _mapper.Map<Query>(queryDTO);
                _query = await queryServices.Update(_query);

                return Ok(_query);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        /// <summary>
        /// This method does the elimination of a query by means of an id.
        /// </summary>
        /// <param name = "queryDTO"> </param>
        /// <param name = "id"> </param>
        /// <returns> </returns>
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            Query query = await queryServices.GetById(id);

            if (query == null)
            {
                return NotFound();
            }

            try
            {
                await queryServices.Delete(id);
                QueryDTO queryDTO = _mapper.Map<QueryDTO>(query);

                return Ok(queryDTO);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}