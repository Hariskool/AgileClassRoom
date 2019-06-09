using AgileClassRoom.Models;
using AgileClassRoom.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgileClassRoom.Interface
{
   public interface ICourse
    {
        void InsertCourse(Course course);
        bool CheckCourseExits(string courseCode);
        CourseViewModel GetCoursebyId(int courseId);
        bool DeleteCourse(int courseId);
        bool UpdateCourse(Course course);
        List<CourseViewModel> GetAllCourses(int userId);
        List<CourseViewModel> GetAllCoursesOfCoordinator(int id);
    }
}
