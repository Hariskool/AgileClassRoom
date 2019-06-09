using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using AgileClassRoom.Interface;
using AgileClassRoom.Models;
using AgileClassRoom.Utility;
using AgileClassRoom.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgileClassRoom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageTeacherController : ControllerBase
    {
        private readonly IUsers _users;
        private readonly ITeacher _teacher;
        private readonly ICoordinator _coordinator;
        private readonly IUsersInRoles _usersInRoles;
        public ManageTeacherController(ICoordinator coordinator,IUsers users, ITeacher teacher, IUsersInRoles usersInRoles)
        {
            _users = users;
            _teacher = teacher;
            _usersInRoles = usersInRoles;
            _coordinator = coordinator;
        }
        [HttpPost]
        public HttpResponseMessage Post([FromBody] TeacherViewModel teacher)
        {
            if (ModelState.IsValid)
            {


                int userId = Convert.ToInt32(this.User.FindFirstValue(ClaimTypes.Name));
                int coorid = _coordinator.GetCoordinatorId(userId);
                var tempUsers = AutoMapper.Mapper.Map<Users>(teacher);
                tempUsers.CreatedDate = DateTime.Now;
                tempUsers.Createdby = userId;
                tempUsers.Password = EncryptLib.EncryptText(teacher.Password);
                _users.InsertUsers(tempUsers);
                var tempTeacher= AutoMapper.Mapper.Map<Teacher>(teacher);
                tempTeacher.DepartmentId = _coordinator.GetCoordinatorDepartmentId(coorid);
                tempTeacher.CreatedBy = coorid;
                tempTeacher.UserID = tempUsers.UserId;
                _teacher.InsertTeacher(tempTeacher);
                UsersInRoles usersInRoles = new UsersInRoles();
                usersInRoles.RoleId = 3;
                usersInRoles.UserId = tempTeacher.UserID;
                _usersInRoles.AssignRole(usersInRoles);

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
        [HttpGet]
        public IEnumerable<TeacherViewModel> Get()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.Name);
            int uId = Convert.ToInt32(userId);
            return _teacher.GetAllTeacher(uId);
        }

        [HttpPut("{id}")]
        public HttpResponseMessage Put(int id, [FromBody] TeacherViewModel teacherViewModel)
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.Name);
                var tempUsers = AutoMapper.Mapper.Map<Users>(teacherViewModel);
                tempUsers.CreatedDate = DateTime.Now;
                tempUsers.Createdby = Convert.ToInt32(userId);
                tempUsers.Password = EncryptLib.EncryptText(teacherViewModel.Password);
                _users.UpdateUsers(tempUsers);
                var tempTeacher = AutoMapper.Mapper.Map<Teacher>(teacherViewModel);
                _teacher.UpdateTeacher(tempTeacher);
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
        [HttpGet("{id}", Name = "GetTeacher")]
        public TeacherViewModel Get(int id)
        {
            try
            {
                return _teacher.GetTeacherbyId(id);
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

                _teacher.DeleteTeacher(id);
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