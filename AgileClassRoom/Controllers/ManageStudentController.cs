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
    public class ManageStudentController : ControllerBase
    {
        private readonly IUsers _users;
        private readonly IStudent _student;
        private readonly ICoordinator _coordinator; 
        private readonly IUsersInRoles _usersInRoles;
        public ManageStudentController(ICoordinator coordinator ,IUsers users, IStudent student, IUsersInRoles usersInRoles)
        {
            _users = users;
            _student = student;
            _usersInRoles = usersInRoles;
            _coordinator = coordinator;
        }
        [HttpPost]
        public HttpResponseMessage Post([FromBody] StudentViewModel student)
        {
            if (ModelState.IsValid)
            {


                int userId = Convert.ToInt32(this.User.FindFirstValue(ClaimTypes.Name));
                int coorid = _coordinator.GetCoordinatorId(userId);
                var tempUsers = AutoMapper.Mapper.Map<Users>(student);
                tempUsers.CreatedDate = DateTime.Now;
                tempUsers.Createdby = userId;
                tempUsers.Password = EncryptLib.EncryptText(student.Password);
                _users.InsertUsers(tempUsers);
                var tempStudent = AutoMapper.Mapper.Map<Student>(student);
                tempStudent.UserID = tempUsers.UserId;
                tempStudent.DepartmentID = _coordinator.GetCoordinatorDepartmentId(coorid);
                _student.InsertStudent(tempStudent);
                UsersInRoles usersInRoles = new UsersInRoles();
                usersInRoles.RoleId = 2;
                usersInRoles.UserId = tempStudent.UserID;
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
        public IEnumerable<StudentViewModel> Get()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.Name);
            int uId = Convert.ToInt32(userId);
            return _student.GetAllStudent(uId);
        }

        [HttpPut("{id}")]
        public HttpResponseMessage Put(int id, [FromBody] StudentViewModel studentViewModel)
        {
            try
            {
                int userId = Convert.ToInt32(this.User.FindFirstValue(ClaimTypes.Name));
                int coorid = _coordinator.GetCoordinatorId(userId);
                var tempUsers = AutoMapper.Mapper.Map<Users>(studentViewModel);
                tempUsers.CreatedDate = DateTime.Now;
                tempUsers.Createdby = Convert.ToInt32(coorid);
                tempUsers.Password = EncryptLib.EncryptText(studentViewModel.Password);
                _users.UpdateUsers(tempUsers);
                var tempStudent = AutoMapper.Mapper.Map<Student>(studentViewModel);
                _student.UpdateStudent(tempStudent);
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
        [HttpGet("{id}", Name = "GetStudent")]
        public StudentViewModel Get(int id)
        {
            try
            {
                return _student.GetStudentbyId(id);
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

                _student.DeleteStudent(id);
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