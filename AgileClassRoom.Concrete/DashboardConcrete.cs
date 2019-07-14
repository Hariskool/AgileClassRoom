using AgileClassRoom.Interface;
using AgileClassRoom.ViewModel;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace AgileClassRoom.Concrete
{
    public class DashboardConcrete : IDashBoard
    {
        private readonly DatabaseContext _context;
        private readonly IConfiguration _configuration;

        public DashboardConcrete(DatabaseContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public AdminDashboardViewModel GetAdminDashboard(int userId)
        {
            var findUser = (from user in _context.Users
                            
                            where user.UserId == userId
                            select user.UserId).FirstOrDefault();
            int techId = Convert.ToInt32(findUser);
            int RoleCount = (from role in _context.Role
                         
                          select role.RoleId).Count();
            int DepartmentCount = (from department in _context.Department

                             select department.DepartmentId).Count();
            int TotalCoordinator = (from coordinator in _context.Coordinator

                                   select coordinator.CoordinatorId).Count();
            int TotalProgram = (from program in _context.Program

                                    select program.ProgramID).Count();
            var result = new AdminDashboardViewModel
            {
                TotalRole = RoleCount,
                TotalCoordinator = TotalCoordinator,
                TotalDepartment = DepartmentCount,
                TotalProgram = TotalProgram

            };




            return result;
        }
        public CoordinatorDashboardViewModel GetCoordinatorDashboard(int userId)
        {
            var findUser = (from coordinator in _context.Coordinator
                            join user in _context.Users on coordinator.UserId equals user.UserId
                            where user.UserId == userId
                            select coordinator.CoordinatorId).FirstOrDefault();
            int coorId = Convert.ToInt32(findUser);

            int CourseCount = (from course in _context.Course
                             where course.CreatedBy== coorId
                             select course.CourseID).Count();

            int SectionCount = (from section in _context.Section
                               where section.CreatedBy == coorId
                               select section.SectionID).Count();
            int TeacherCount = (from techer in _context.Teacher
                                where techer.CreatedBy == coorId
                                select techer.TeacherID).Count();
            int StudentCount = (from student in _context.Student
                                where student.CreatedBy == coorId
                                select student.StudentID).Count();

            var result = new CoordinatorDashboardViewModel
            {
                TotalCourse = CourseCount,
                TotalSection = SectionCount,
                TotalTeacher = TeacherCount,
                TotalStudent = StudentCount

            };


            throw new NotImplementedException();
        }

        public StudentDashboardViewModel GetStudentDashboard(int userId)
        {
            throw new NotImplementedException();
        }

        public TeacherDashBoardViewModel GetTeacherDashboard(int userId)
        {
            var findUser = (from teacher in _context.Teacher
                            join user in _context.Users on teacher.UserID equals user.UserId
                            where user.UserId == userId
                            select teacher.TeacherID).FirstOrDefault();
            int techId = Convert.ToInt32(findUser);

            int ProjectCount = (from course in _context.Project
                               where course.createdBy == techId
                                select course.projectId).Count();

            int AnnoucementCount = (from annoucement in _context.Annoucement
                                where annoucement.createdBy == techId
                                select annoucement.annoucementId).Count();
            int AssessementCount = (from assessment in _context.Assessment
                                where assessment.createdBy == techId
                                select assessment.assessmentId).Count();
            int GroupCount = (from groups in _context.Groups
                                where groups.createdBy== techId
                                select groups.groupId).Count();
            var result = new TeacherDashBoardViewModel
            {
                TotalProjects = ProjectCount,
                TotalAnnoucement = AnnoucementCount,
                TotalAssessment = AssessementCount,
                TotalGroups = GroupCount

            };
            return result;
        }
    }
}
