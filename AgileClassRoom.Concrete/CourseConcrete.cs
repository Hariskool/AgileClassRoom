using AgileClassRoom.Interface;
using AgileClassRoom.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AgileClassRoom.ViewModel;
using System.Security.Claims;

namespace AgileClassRoom.Concrete
{
    public class CourseConcrete : ICourse
    {
        private readonly DatabaseContext _context;
        private readonly IConfiguration _configuration;

        public CourseConcrete(DatabaseContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public void InsertCourse(Course course)
        {
            _context.Course.Add(course);
            _context.SaveChanges();

        }
        public bool CheckCourseExits(string CourseCode)
        {
            var result = (from course in _context.Course
                          where course.CourseCode == CourseCode
                          select course).Count();

            return result > 0 ? true : false;
        }

        public CourseViewModel GetCoursebyId(int courseID)
        {
            var result = (from course in _context.Course
                          join program in _context.Program on course.ProgramID equals program.ProgramID
                          
                          where course.CourseID == courseID

                          select new CourseViewModel
                          {
                              CourseID = course.CourseID,
                              CourseCode = course.CourseCode,
                              CourseName = course.CourseName,
                              CreditHours = course.CreditHours,
                              ProgramID = program.ProgramID,
                              ProgramInfo = program.ProgramName
    }).FirstOrDefault();

            return result;
        }
        public bool DeleteCourse(int courseId)
        {
            var course = (from courses in _context.Course
                               where courses.CourseID == courseId
                               select courses).FirstOrDefault();
            
            if (course != null)
            {
                _context.Course.Remove(course);
               

                var result = _context.SaveChanges();

                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool UpdateCourse(Course course)
        {

            _context.Entry(course).Property(x => x.CourseName).IsModified = true;
            var result = _context.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
       public List<CourseViewModel> GetAllCoursesOfCoordinator(int id)
        {

            var result = (from courses in _context.Course
                          join program in _context.Program on courses.ProgramID equals program.ProgramID
                          where courses.CreatedBy == id
                          select new CourseViewModel
                          {
                              CourseID = courses.CourseID,
                              CourseCode = courses.CourseCode,
                              CourseName = courses.CourseName,
                              CreditHours = courses.CreditHours,
                              ProgramID = program.ProgramID,
                              ProgramInfo = program.ProgramName
                          }
                          ).ToList();

            return result;
        }
        public List<CourseViewModel> GetAllCourses(int userId)
        {
            var findUser = (from coordinator in _context.Coordinator
                            join user in _context.Users on coordinator.UserId equals user.UserId
                            where user.UserId == userId
                            select coordinator.CoordinatorId).FirstOrDefault();
            int coorId = Convert.ToInt32(findUser);

            var result = (from courses in _context.Course
                          join program in _context.Program on courses.ProgramID equals program.ProgramID
                          where courses.CreatedBy == coorId
                          select new CourseViewModel
                          {
                              CourseID = courses.CourseID,
                              CourseCode = courses.CourseCode,
                              CourseName = courses.CourseName,
                              CreditHours = courses.CreditHours,
                              ProgramID = program.ProgramID,
                              ProgramInfo = program.ProgramName
                          }
                          ).ToList();

            return result;
        }
    }
}
