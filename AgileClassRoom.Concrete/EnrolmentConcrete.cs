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
    public class EnrolmentConcrete : IEnrolment
    {
        private readonly DatabaseContext _context;
        private readonly IConfiguration _configuration;

        public EnrolmentConcrete(DatabaseContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public void InsertEnrolment(Enrolment enrol)
        {
            _context.Enrolment.Add(enrol);
            _context.SaveChanges();

        }
       public bool CheckEnrolmentExits(int studentId, int sectionId)
        {
            var result = (from enrol in _context.Enrolment
                          where enrol.StudentID == studentId
                          && enrol.SectionID == sectionId
                          select enrol).Count();

            return result > 0 ? true : false;
        }
        public EnrolViewModel GetEnrolmentbyId(int enrolId)
        {
            var result = (from enrol in _context.Enrolment
                          join student in _context.Student on enrol.StudentID equals student.StudentID
                          join section in _context.Section on enrol.SectionID equals section.SectionID
                          join course in _context.Course on section.CourseID equals course.CourseID
                          join user in _context.Users on student.UserID equals user.UserId
                          where enrol.EnrolmentID == enrolId

                          select new EnrolViewModel
                          {
                             EnrolmentID = enrol.EnrolmentID,
                             SectionID = section.SectionID,
                             SectionNo = section.SectionNo,
                             CourseName = course.CourseName,
                             StudentID = student.StudentID,
                             StudentName = user.FullName
                          }).FirstOrDefault();

            return result;
        }
        public bool DeleteEnrolment(int enrolId)
        {
            var enrols = (from enrol in _context.Enrolment
                          where enrol.EnrolmentID == enrolId
                          select enrol).FirstOrDefault();

            if (enrols != null)
            {
                _context.Enrolment.Remove(enrols);


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
        public bool UpdateEnrolment(Enrolment enrol)
        {

            _context.Entry(enrol).Property(x => x.SectionID).IsModified = true;
            _context.Entry(enrol).Property(x => x.StudentID).IsModified = true;
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
        public List<EnrolViewModel> GetAllEnrolment(int userId)
        {
            var findUser = (from coordinator in _context.Coordinator
                            join user in _context.Users on coordinator.UserId equals user.UserId
                            where user.UserId == userId
                            select coordinator.CoordinatorId).FirstOrDefault();
            int coorId = Convert.ToInt32(findUser);

            var result = (from enrol in _context.Enrolment
                          join student in _context.Student on enrol.StudentID equals student.StudentID
                          join section in _context.Section on enrol.SectionID equals section.SectionID
                          join course in _context.Course on section.CourseID equals course.CourseID
                          join user in _context.Users on student.UserID equals user.UserId
                          where enrol.CreatedBy == coorId
                          select new EnrolViewModel
                          {
                              EnrolmentID = enrol.EnrolmentID,
                              SectionID = section.SectionID,
                              SectionNo = section.SectionNo,
                              CourseName = course.CourseName,
                              StudentID = student.StudentID,
                              StudentName = user.FullName
                          }).ToList();

            return result;
        }
    }

}

