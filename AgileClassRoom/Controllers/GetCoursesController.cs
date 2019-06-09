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
    public class GetCoursesController : ControllerBase
    {
        private readonly ICourse _course;
        private readonly ICoordinator _coordinator;
        public GetCoursesController(ICourse course, ICoordinator coordinator)
        {

            _course = course;
            _coordinator = coordinator;
        }
        [HttpGet]
        public IEnumerable<CourseViewModel> Get()
        {
            int userId = Convert.ToInt32(this.User.FindFirstValue(ClaimTypes.Name));
            int coorid = _coordinator.GetCoordinatorId(userId);

            return _course.GetAllCoursesOfCoordinator(coorid);
        }
    }
}