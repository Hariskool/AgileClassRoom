using AgileClassRoom.Interface;
using AgileClassRoom.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AgileClassRoom.ViewModel;

namespace AgileClassRoom.Concrete
{
   public class AssignProjectConcrete : IAssignProject
    {
        private readonly DatabaseContext _context;
        private readonly IConfiguration _configuration;

        public AssignProjectConcrete(DatabaseContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public void InsertAssignProject(AssignProject assignProject)
        {
            _context.AssignProject.Add(assignProject);
            _context.SaveChanges();

        }
        public bool CheckAssignProjectExits(int projectId,int sectionId)
        {
            var result = (from assignProject in _context.AssignProject
                          where assignProject.projectId == projectId && assignProject.sectionId == sectionId

                          select assignProject).Count();
            //
            return result > 0 ? true : false;
        }

        public AssignProjectViewModel GetAssignProjectbyId(int assignProjectId)
        {
            var result = (from assignProject in _context.AssignProject
                          join section in _context.Section on assignProject.sectionId equals section.SectionID
                          join course in _context.Course on section.CourseID equals course.CourseID
                          join project in _context.Project on assignProject.projectId equals project.projectId

                          where assignProject.assignProjectId == assignProjectId
                          select new AssignProjectViewModel
                          {
                              assignProjectId = assignProject.assignProjectId,
                              courseId = course.CourseID,
                              courseName = course.CourseName,
                              projectId = project.projectId,
                              projectName = project.name,
                              sectionId= section.SectionID,
                              sectionNo = section.SectionNo
                          }).FirstOrDefault();

            return result;
        }
        public bool DeleteAssignProject(int assignProjectId)
        {
            var delresult = (from assignProject in _context.AssignProject
                             where assignProject.assignProjectId == assignProjectId
                             select assignProject).FirstOrDefault();

            if (delresult != null)
            {
                _context.AssignProject.Remove(delresult);


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

        public bool UpdateAssignProject(AssignProject assignProject)
        {

            _context.Entry(assignProject).Property(x => x.courseId).IsModified = true;
            _context.Entry(assignProject).Property(x => x.sectionId).IsModified = true;
            _context.Entry(assignProject).Property(x => x.projectId).IsModified = true;
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
       public List<CourseViewModel> GetTeacherCourses(int userId)
        {
            var findUser = (from teacher in _context.Teacher
                            join user in _context.Users on teacher.UserID equals user.UserId
                            where user.UserId == userId
                            select teacher.TeacherID).FirstOrDefault();
            int techId = Convert.ToInt32(findUser);
            var result = (from course in _context.Course
                          join section in _context.Section on course.CourseID equals section.CourseID
                          join teacher in _context.Teacher on section.TeacherID equals teacher.TeacherID
                          where teacher.TeacherID == techId
                          select new CourseViewModel
                          {
                              
                              CourseID = course.CourseID,
                              CourseName = course.CourseName,
                              
                          }).ToList();

            return result;
        }
        public List<SectionViewModel> GetTeacherSections(int userId,int courseId) {
            var findUser = (from teacher in _context.Teacher
                            join user in _context.Users on teacher.UserID equals user.UserId
                            where user.UserId == userId
                            select teacher.TeacherID).FirstOrDefault();
            int techId = Convert.ToInt32(findUser);
            var result = (from course in _context.Course
                          join section in _context.Section on course.CourseID equals section.CourseID
                          join teacher in _context.Teacher on section.TeacherID equals teacher.TeacherID
                          where teacher.TeacherID == techId && course.CourseID == courseId
                          select new SectionViewModel
                          {
                              
                              SectionID = section.SectionID,
                              SectionNo = section.SectionNo
                              
                          }).ToList();

            return result;
        }
        public List<AssignProjectViewModel> GetAllAssignProjects(int userId)
        {
            var findUser = (from teacher in _context.Teacher
                            join user in _context.Users on teacher.UserID equals user.UserId
                            where user.UserId == userId
                            select teacher.TeacherID).FirstOrDefault();
            int techId = Convert.ToInt32(findUser);

            var result = (from assignProject in _context.AssignProject
                          join section in _context.Section on assignProject.sectionId equals section.SectionID
                          join course in _context.Course on section.CourseID equals course.CourseID
                          join project in _context.Project on assignProject.projectId equals project.projectId

                          where assignProject.createdBy == techId
                          select new AssignProjectViewModel
                          {
                              assignProjectId = assignProject.assignProjectId,
                              courseId = course.CourseID,
                              courseName = course.CourseName,
                              projectId = project.projectId,
                              projectName = project.name,
                              sectionId = section.SectionID,
                              sectionNo = section.SectionNo
                          }).ToList();

            return result;
        }
    }
}