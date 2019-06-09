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
    public class ManageSectionController : ControllerBase
    {
        private readonly ISection _section;
        private readonly ICoordinator _coordinator;
        public ManageSectionController(ISection section, ICoordinator coordinator)
        {
            _section = section;
            _coordinator = coordinator;
        }
        // GET: api/User
        [HttpGet]
        public IEnumerable<SectionViewModel> Get()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.Name);
            int uId = Convert.ToInt32(userId);
            return _section.GetAllSections(uId);
        }
        [HttpPost]
        public HttpResponseMessage Post([FromBody] SectionViewModel section)
        {
            if (ModelState.IsValid)
            {
                if (_section.CheckSectionExits(section.SectionNo,section.CourseID))
                {
                    var responseCheck = new HttpResponseMessage()
                    {
                        StatusCode = HttpStatusCode.Conflict
                    };

                    return responseCheck;
                }

                int userId = Convert.ToInt32(this.User.FindFirstValue(ClaimTypes.Name));
                int coorid = _coordinator.GetCoordinatorId(userId);
                var tempSection = AutoMapper.Mapper.Map<Section>(section);
                tempSection.CreatedBy = coorid;
                _section.InsertSection(tempSection);


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
        public HttpResponseMessage Put(int id, [FromBody] SectionViewModel sectionViewModel)
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.Name);
                var tempSection = AutoMapper.Mapper.Map<Section>(sectionViewModel);
                _section.UpdateSection(tempSection);

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
        [HttpGet("{id}", Name = "GetSection")]
        public SectionViewModel Get(int id)
        {
            try
            {
                return _section.GetSectionbyId(id);
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

                _section.DeleteSection(id);
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