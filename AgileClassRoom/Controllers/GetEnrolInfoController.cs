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
    public class GetEnrolInfoController : ControllerBase
    {
        private readonly ISection _section;
        private readonly ICoordinator _coordinator;
        private readonly IStudent _student;
        public GetEnrolInfoController(ISection section, ICoordinator coordinator, IStudent student)
        {
            _section = section;
            _coordinator = coordinator;
            _student = student;
        }

        [Route("SectionDATA")]
        [HttpGet]
        public IEnumerable<SectionViewModel> SectionData()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.Name);
            int uId = Convert.ToInt32(userId);
            return _section.GetAllSections(uId);
        }
        [Route("StudentDATA")]
        [HttpGet]
        public IEnumerable<StudentViewModel> StudentData(int courseId)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.Name);
            int uId = Convert.ToInt32(userId);
            return _student.GetAllStudentbycourse(0,uId);
        }
    }
}