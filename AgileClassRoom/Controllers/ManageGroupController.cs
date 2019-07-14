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
    public class ManageGroupController : ControllerBase
    {
        private readonly IGroup _group;
        private readonly IGroupMember _groupMember;
        private readonly ITeacher _teacher;
        public ManageGroupController(IGroup group, IGroupMember groupMember, ITeacher teacher)
        {
            _group = group;
            _groupMember = groupMember;
            _teacher = teacher;
        }
        // GET: api/Annoucement
        [HttpGet]
        public IEnumerable<GroupViewModel> Get()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.Name);
            int uId = Convert.ToInt32(userId);
            return _group.GetAllGroups(uId);
        }
        [HttpPost]
        public HttpResponseMessage Post([FromBody] GroupsViewModel group)
        {
            if (ModelState.IsValid)
            {


                int userId = Convert.ToInt32(this.User.FindFirstValue(ClaimTypes.Name));
                int coorid = _teacher.GetTeacherId(userId);
                 var tempEnrol = AutoMapper.Mapper.Map<Groups>(group);
                tempEnrol.createdBy = coorid;
               
                _group.InsertGroup(tempEnrol);


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
        public HttpResponseMessage Put(int id, [FromBody] GroupViewModel group )
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.Name);
                var tempEnrol = AutoMapper.Mapper.Map<Groups>(group);
                _group.UpdateGroup(tempEnrol);

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
        [HttpGet("{id}", Name = "GetGroup")]
        public GroupViewModel Get(int id)
        {
            try
            {
                return _group.GetGroupbyId(id);
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

                _group.DeleteGroup(id);
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