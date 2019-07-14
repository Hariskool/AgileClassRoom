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
    public class GetEnrolledStudentsController : ControllerBase
    {
        private readonly ITeacher _teacher;
       
        public GetEnrolledStudentsController(ITeacher teacher)
        {

            _teacher = teacher;
          
        }
        [HttpGet]
        public IEnumerable<RegisteredStudentViewModel> Get()
        {
            int userId = Convert.ToInt32(this.User.FindFirstValue(ClaimTypes.Name));
            int uId = Convert.ToInt32(userId);

            return _teacher.GetAllStudentsOfTeacher(uId);
        }
    }
}