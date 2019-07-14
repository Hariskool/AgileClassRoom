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
    public class ManageProjectController : ControllerBase
    {
        private readonly IProject _project;
        private readonly ITeacher _teacher;
        public ManageProjectController(IProject project, ITeacher teacher)
        {
            _project = project;
            _teacher = teacher;
        }
        // GET: api/Annoucement
        [HttpGet]
        public IEnumerable<ProjectViewModel> Get()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.Name);
            int uId = Convert.ToInt32(userId);
            return _project.GetAllProjects(uId);
        }
        [HttpPost]
        public HttpResponseMessage Post([FromBody] ProjectViewModel project)
        {
            if (ModelState.IsValid)
            {


                int userId = Convert.ToInt32(this.User.FindFirstValue(ClaimTypes.Name));
                int coorid = _teacher.GetTeacherId(userId);
                var tempEnrol = AutoMapper.Mapper.Map<Project>(project);
                tempEnrol.createdBy = coorid;
                tempEnrol.IssueDate = DateTime.Today;
                _project.InsertProject(tempEnrol);


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
        public HttpResponseMessage Put(int id, [FromBody] ProjectViewModel project)
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.Name);
                var tempEnrol = AutoMapper.Mapper.Map<Project>(project);
                _project.UpdateProject(tempEnrol);

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
        [HttpGet("{id}", Name = "GetProject")]
        public ProjectViewModel Get(int id)
        {
            try
            {
                return _project.GetProjectbyId(id);
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

                _project.DeleteProject(id);
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