using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using AgileClassRoom.ViewModel;
using AgileClassRoom.Models;
using AgileClassRoom.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AgileClassRoom.Utility;

namespace AgileClassRoom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageCoordinatorController : ControllerBase
    {
        private readonly IUsers _users;
        private readonly ICoordinator _coordinator;
        private readonly IUsersInRoles _usersInRoles;
        public ManageCoordinatorController(IUsers users,ICoordinator coordinator, IUsersInRoles usersInRoles)
        {
            _users = users;
            _coordinator = coordinator;
            _usersInRoles = usersInRoles;
        }
        [HttpPost]
        public HttpResponseMessage Post([FromBody] CoordinatorViewModel coordinator) {
            if (ModelState.IsValid)
            {
                
                
                    var userId = this.User.FindFirstValue(ClaimTypes.Name);
                    var tempUsers = AutoMapper.Mapper.Map<Users>(coordinator);
                    tempUsers.CreatedDate = DateTime.Now;
                    tempUsers.Createdby = Convert.ToInt32(userId);
                    tempUsers.Password = EncryptLib.EncryptText(coordinator.Password);
                    _users.InsertUsers(tempUsers);
                var tempCoordinator = AutoMapper.Mapper.Map<Coordinator>(coordinator);
                tempCoordinator.UserId = tempUsers.UserId;
                _coordinator.InsertCoordinator(tempCoordinator);
                UsersInRoles usersInRoles = new UsersInRoles();
                usersInRoles.RoleId = 4;
                usersInRoles.UserId = tempCoordinator.UserId;
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
        public IEnumerable<CoordinatorViewModel> Get()
        {
            return _coordinator.GetAllCoordinator();
        }

        [HttpPut("{id}")]
        public HttpResponseMessage Put(int id, [FromBody] CoordinatorViewModel coordinatorViewModel)
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.Name);
                var tempUsers = AutoMapper.Mapper.Map<Users>(coordinatorViewModel);
                tempUsers.CreatedDate = DateTime.Now;
                tempUsers.Createdby = Convert.ToInt32(userId);
                tempUsers.Password = EncryptLib.EncryptText(coordinatorViewModel.Password);
                _users.UpdateUsers(tempUsers);
                var tempCoordinator = AutoMapper.Mapper.Map<Coordinator>(coordinatorViewModel);
                _coordinator.UpdateCoordinator(tempCoordinator);
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
        [HttpGet("{id}", Name = "GetCoordinator")]
        public CoordinatorViewModel Get(int id)
        {
            try
            {
                return _coordinator.GetCoordinatorbyId(id);
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

                _coordinator.DeleteCoordinator(id);
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