using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AgileClassRoom.Interface;
using AgileClassRoom.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgileClassRoom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetTeachersController : ControllerBase
    {
        private readonly ITeacher _teacher;
        private readonly ICoordinator _coordinator;
        public GetTeachersController(ITeacher teacher, ICoordinator coordinator)
        {

            _teacher = teacher;
            _coordinator = coordinator;
        }
        [HttpGet]
        public IEnumerable<TeacherViewModel> Get()
        {
            int userId = Convert.ToInt32(this.User.FindFirstValue(ClaimTypes.Name));
            int coorid = _coordinator.GetCoordinatorId(userId);

            return _teacher.GetAllTeachersOfCoordinator(coorid);
        }
    }
}