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
    public class ManageAssessmentController :  ControllerBase
    {
        private readonly IAssessment _assessment;
        private readonly ITeacher _teacher;
        public ManageAssessmentController(IAssessment assessment, ITeacher teacher)
        {
            _assessment = assessment;
            _teacher = teacher;
        }
        // GET: api/Annoucement
        [HttpGet]
        public IEnumerable<AssessmentViewModel> Get()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.Name);
            int uId = Convert.ToInt32(userId);
            return _assessment.GetAllAssessments(uId);
        }
        [HttpPost]
        public HttpResponseMessage Post([FromBody] Assessment assessment)
        {
            if (ModelState.IsValid)
            {


                int userId = Convert.ToInt32(this.User.FindFirstValue(ClaimTypes.Name));
                int coorid = _teacher.GetTeacherId(userId);
               // var tempEnrol = AutoMapper.Mapper.Map<Assessment>(assessment);
                assessment.createdBy = coorid;
                assessment.createdDate = DateTime.Today;
                _assessment.InsertAssessment(assessment);


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
        public HttpResponseMessage Put(int id, [FromBody] Assessment assessment)
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.Name);
               // var tempEnrol = AutoMapper.Mapper.Map<Assessment>(assessment);
                _assessment.UpdateAssessment(assessment);

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
        [HttpGet("{id}", Name = "GetAssessment")]
        public AssessmentViewModel Get(int id)
        {
            try
            {
                return _assessment.GetAssessmentbyId(id);
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

                _assessment.DeleteAssessment(id);
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