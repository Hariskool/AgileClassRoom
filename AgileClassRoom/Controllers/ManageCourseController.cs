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
    public class ManageCourseController : ControllerBase
    {
        private readonly ICourse _courses;
        private readonly ICoordinator _coordinator;
        public ManageCourseController(ICourse course, ICoordinator coordinator)
        {
            _courses = course;
            _coordinator = coordinator;
        }
        // GET: api/User
        [HttpGet]
        public IEnumerable<CourseViewModel> Get()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.Name);
            int uId = Convert.ToInt32(userId);
            return _courses.GetAllCourses(uId);
        }
        [HttpPost]
        public HttpResponseMessage Post([FromBody] CourseViewModel course)
        {
            if (ModelState.IsValid)
            {


                int userId = Convert.ToInt32(this.User.FindFirstValue(ClaimTypes.Name));
                int coorid = _coordinator.GetCoordinatorId(userId);
                var tempCourse = AutoMapper.Mapper.Map<Course>(course);
                tempCourse.CreatedBy = coorid;
                _courses.InsertCourse(tempCourse);
                

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
        public HttpResponseMessage Put(int id, [FromBody] CourseViewModel courseViewModel)
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.Name);
                var tempUsers = AutoMapper.Mapper.Map<Course>(courseViewModel);
                _courses.UpdateCourse(tempUsers);
                
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
        [HttpGet("{id}", Name = "GetCourse")]
        public CourseViewModel Get(int id)
        {
            try
            {
                return _courses.GetCoursebyId(id);
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

                _courses.DeleteCourse(id);
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