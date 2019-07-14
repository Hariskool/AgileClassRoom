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
    public class ManageAssignProjectController : ControllerBase
    {
        private readonly IAssignProject _assignProject;
        private readonly ITeacher _teacher;
        public ManageAssignProjectController(IAssignProject assignProject, ITeacher teacher)
        {
            _assignProject = assignProject;
            _teacher = teacher;
        }
        // GET: api/Annoucement
        [HttpGet]
        public IEnumerable<AssignProjectViewModel> Get()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.Name);
            int uId = Convert.ToInt32(userId);
            return _assignProject.GetAllAssignProjects(uId);
        }
        [HttpPost]
        public HttpResponseMessage Post([FromBody] AssignProjectViewModel assignProject)
        {
            if (ModelState.IsValid)
            {


                int userId = Convert.ToInt32(this.User.FindFirstValue(ClaimTypes.Name));
                int coorid = _teacher.GetTeacherId(userId);
                var tempEnrol = AutoMapper.Mapper.Map<AssignProject>(assignProject);
                tempEnrol.createdBy = coorid;
                
                _assignProject.InsertAssignProject(tempEnrol);


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
        public HttpResponseMessage Put(int id, [FromBody] AssignProjectViewModel assignProject)
        { 
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.Name);
                var tempEnrol = AutoMapper.Mapper.Map<AssignProject>(assignProject);
                _assignProject.UpdateAssignProject(tempEnrol);

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
        [HttpGet("{id}", Name = "GetAssignProject")]
        public AssignProjectViewModel Get(int id)
        {
            try
            {
                return _assignProject.GetAssignProjectbyId(id);
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

                _assignProject.DeleteAssignProject(id);
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