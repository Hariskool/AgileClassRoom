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
    public class SectionConcrete : ISection
    {
        private readonly DatabaseContext _context;
        private readonly IConfiguration _configuration;

        public SectionConcrete(DatabaseContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public void InsertSection(Section section)
        {
            _context.Section.Add(section);
            _context.SaveChanges();

        }
        public bool CheckSectionExits(int sectionNo, int courseid)
        {
            var result = (from section in _context.Section
                          where section.SectionNo == sectionNo
                          && section.CourseID==courseid
                          select section).Count();
            //
            return result > 0 ? true : false;
        }

        public SectionViewModel GetSectionbyId(int sectionId)
        {
            var result = (from section in _context.Section
                          join teacher in _context.Teacher on section.TeacherID equals teacher.TeacherID
                          join course in _context.Course on section.CourseID equals course.CourseID
                          join user in _context.Users on teacher.UserID equals user.UserId

                          where section.SectionID == sectionId

                          select new SectionViewModel
                          {
                             CourseName = course.CourseName,
                             SectionID =section.SectionID,
                             SectionNo= section.SectionNo,
                             teacherName = user.FullName
                          }).FirstOrDefault();

            return result;
        }
        public bool DeleteSection(int sectionId)
        {
            var delresult = (from section in _context.Section
                          where section.SectionID == sectionId
                          select section).FirstOrDefault();

            if (delresult != null)
            {
                _context.Section.Remove(delresult);


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

        public bool UpdateSection(Section section)
        {

            _context.Entry(section).Property(x => x.SectionNo).IsModified = true;
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
        public List<SectionViewModel> GetAllSections(int userId)
        {
            var findUser = (from coordinator in _context.Coordinator
                            join user in _context.Users on coordinator.UserId equals user.UserId
                            where user.UserId == userId
                            select coordinator.CoordinatorId).FirstOrDefault();
            int coorId = Convert.ToInt32(findUser);

            var result = (from section in _context.Section
                          join teacher in _context.Teacher on section.TeacherID equals teacher.TeacherID
                          join course in _context.Course on section.CourseID equals course.CourseID
                          join user in _context.Users on teacher.UserID equals user.UserId

                          where section.CreatedBy == coorId

                          select new SectionViewModel
                          {
                              CourseID=course.CourseID,
                              CourseName = course.CourseName,
                              SectionID = section.SectionID,
                              SectionNo = section.SectionNo,
                              teacherName = user.FullName
                          }).ToList();
            return result;
        }
    }
}