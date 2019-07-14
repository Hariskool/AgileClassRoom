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
    public class ManageAnnoucementController : ControllerBase
    {
        private readonly IAnnoucement _annoucement;
        private readonly ITeacher _teacher;
        public ManageAnnoucementController(IAnnoucement annoucement, ITeacher teacher)
        {
            _annoucement = annoucement;
            _teacher = teacher;
        }
        // GET: api/Annoucement
        [HttpGet]
        public IEnumerable<AnnoucementViewModel> Get()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.Name);
            int uId = Convert.ToInt32(userId);
            return _annoucement.GetAllAnnoucements(uId);
        }
        [HttpPost]
        public HttpResponseMessage Post([FromBody] AnnoucementViewModel annoucement)
        {
            if (ModelState.IsValid)
            {


                int userId = Convert.ToInt32(this.User.FindFirstValue(ClaimTypes.Name));
                int coorid = _teacher.GetTeacherId(userId);
                var tempEnrol = AutoMapper.Mapper.Map<Annoucement>(annoucement);
                tempEnrol.createdBy = coorid;
                _annoucement.InsertAnnoucement(tempEnrol);


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
        public HttpResponseMessage Put(int id, [FromBody] AnnoucementViewModel annoucement)
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.Name);
                var tempEnrol = AutoMapper.Mapper.Map<Annoucement>(annoucement);
                _annoucement.UpdateAnnoucement(tempEnrol);

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
        [HttpGet("{id}", Name = "GetAnnouce")]
        public AnnoucementViewModel Get(int id)
        {
            try
            {
                return _annoucement.GetAnnoucementbyId(id);
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

                _annoucement.DeleteAnnoucement(id);
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