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
    public class DashboardController : ControllerBase
    {
        private readonly IDashBoard _dashbard;
        public DashboardController(IDashBoard dashbard)
        {
            _dashbard = dashbard;
        }
        [Route("AdminDashboard")]
        [HttpGet]
        public AdminDashboardViewModel AdminDashboard()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.Name);
            int uId = Convert.ToInt32(userId);
            return _dashbard.GetAdminDashboard(uId);
        }
        [Route("TeacherDashboard")]
        [HttpGet]
        public TeacherDashBoardViewModel TeacherDashboard()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.Name);
            int uId = Convert.ToInt32(userId);
            return _dashbard.GetTeacherDashboard(uId);
        }

        [Route("CoordinatorDashboard")]
        [HttpGet]
        public CoordinatorDashboardViewModel CoordinatorDashboard()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.Name);
            int uId = Convert.ToInt32(userId);
            return _dashbard.GetCoordinatorDashboard(uId);
        }
        [Route("StudentDashboard")]
        [HttpGet]
        public StudentDashboardViewModel StudentDashboard()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.Name);
            int uId = Convert.ToInt32(userId);
            return _dashbard.GetStudentDashboard(uId);
        }
    }
}