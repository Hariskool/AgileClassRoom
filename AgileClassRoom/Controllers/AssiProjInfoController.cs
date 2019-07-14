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
    public class AssiProjInfoController : ControllerBase
    {
        private readonly IAssignProject _assignProject;
        private readonly ITeacher _teacherProject;

        public AssiProjInfoController(IAssignProject assignProject, ITeacher teacherProject)
        {
            _assignProject = assignProject;
            _teacherProject = teacherProject;

        }

        [Route("TeacherCourses")]
        [HttpGet]
        public IEnumerable<CourseViewModel> TeacherCourses()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.Name);
            int uId = Convert.ToInt32(userId);
            return _assignProject.GetTeacherCourses(uId);
        }
        [Route("TeacherStundents")]
        [HttpGet]
        public IEnumerable<RegisteredStudentViewModel> TeacherStudents()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.Name);
            int uId = Convert.ToInt32(userId);
            return _teacherProject.GetAllStudentsOfTeacher(uId);
        }
        [Route("TeacherSections")]
        [HttpGet]
        public IEnumerable<SectionViewModel> TeacherSections(int courseId)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.Name);
            int uId = Convert.ToInt32(userId);
            return _assignProject.GetTeacherSections(uId, courseId);
        }

    }
}