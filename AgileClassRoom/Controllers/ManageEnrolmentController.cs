using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using AgileClassRoom.Interface;
using AgileClassRoom.Models;
using AgileClassRoom.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgileClassRoom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageEnrolmentController : ControllerBase
    {
        private readonly IEnrolment _enrolment;
        private readonly ICoordinator _coordinator;
        public ManageEnrolmentController(IEnrolment enrolment, ICoordinator coordinator)
        {
            _enrolment = enrolment;
            _coordinator = coordinator;
        }
        // GET: api/Enrol
        [HttpGet]
        public IEnumerable<EnrolViewModel> Get()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.Name);
            int uId = Convert.ToInt32(userId);
            return _enrolment.GetAllEnrolment(uId);
        }
        [HttpPost]
        public HttpResponseMessage Post([FromBody] EnrolViewModel enrol)
        {
            if (ModelState.IsValid)
            {


                int userId = Convert.ToInt32(this.User.FindFirstValue(ClaimTypes.Name));
                int coorid = _coordinator.GetCoordinatorId(userId);
                var tempEnrol = AutoMapper.Mapper.Map<Enrolment>(enrol);
                tempEnrol.CreatedBy = coorid;
                _enrolment.InsertEnrolment(tempEnrol);


                var response = new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK
                };

                return response;

            }
            else
            {
                var response = new HttpResponseMessage()
                {

                    StatusCode = HttpStatusCode.BadRequest
                };

                return response;
            }

        }
        [HttpPut("{id}")]
        public HttpResponseMessage Put(int id, [FromBody] EnrolViewModel enrol)
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.Name);
                var tempEnrol = AutoMapper.Mapper.Map<Enrolment>(enrol);
                _enrolment.UpdateEnrolment(tempEnrol);

                var response = new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK
                };

                return response;
            }
            catch (Exception)
            {
                var response = new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.InternalServerError
                };
                return response;
            }
        }
        [HttpGet("{id}", Name = "GetEnrolment")]
        public EnrolViewModel Get(int id)
        {
            try
            {
                return _enrolment.GetEnrolmentbyId(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpDelete("{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {

                _enrolment.DeleteEnrolment(id);
                var response = new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK
                };

                return response;
            }
            catch (Exception)
            {
                var response = new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.InternalServerError
                };
                return response;
            }
        }

    }
}