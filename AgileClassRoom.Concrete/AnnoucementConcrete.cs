using AgileClassRoom.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.Extensions.Configuration;
using AgileClassRoom.Models;
using AgileClassRoom.ViewModel;

namespace AgileClassRoom.Concrete
{
    public class AnnoucementConcrete : IAnnoucement
    {
        private readonly DatabaseContext _context;
        private readonly IConfiguration _configuration;

        public AnnoucementConcrete(DatabaseContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public void InsertAnnoucement(Annoucement annoucement)
        {
            _context.Annoucement.Add(annoucement);
            _context.SaveChanges();

        }
        //public bool CheckAnnoucementExits(int projectId, int sectionId)
        //{
        //    var result = (from assignProject in _context.AssignProject
        //                  where assignProject.projectId == projectId && assignProject.sectionId == sectionId

        //                  select assignProject).Count();
        //    //
        //    return result > 0 ? true : false;
        //}

        public AnnoucementViewModel GetAnnoucementbyId(int annoucementId)
        {
            var result = (from annoucement in _context.Annoucement
                          join section in _context.Section on annoucement.sectionId equals section.SectionID
                          join course in _context.Course on section.CourseID equals course.CourseID
                         where annoucement.annoucementId == annoucementId
                          select new AnnoucementViewModel
                          {
                              annoucementId=annoucement.annoucementId,
                              description=annoucement.description,
                              expireDate=annoucement.expireDate,
                              sectionId = section.SectionID,
                              sectionNo = section.SectionNo,
                              CourseName = course.CourseName
                          }).FirstOrDefault();

            return result;
        }
        public bool DeleteAnnoucement(int annoucementId)
        {
            var delresult = (from annoucement in _context.Annoucement
                             where annoucement.annoucementId == annoucementId
                             select annoucement).FirstOrDefault();

            if (delresult != null)
            {
                _context.Annoucement.Remove(delresult);


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

        public bool UpdateAnnoucement(Annoucement annoucement)
        {

            _context.Entry(annoucement).Property(x => x.description).IsModified = true;
            _context.Entry(annoucement).Property(x => x.sectionId).IsModified = true;
            _context.Entry(annoucement).Property(x => x.expireDate).IsModified = true;
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
        public List<AnnoucementViewModel> GetAllAnnoucements(int userId)
        {
            var findUser = (from teacher in _context.Teacher
                            join user in _context.Users on teacher.UserID equals user.UserId
                            where user.UserId == userId
                            select teacher.TeacherID).FirstOrDefault();
            int techId = Convert.ToInt32(findUser);

            var result = (from annoucement in _context.Annoucement
                          join section in _context.Section on annoucement.sectionId equals section.SectionID
                          join course in _context.Course on section.CourseID equals course.CourseID
                          where annoucement.createdBy == techId
                          select new AnnoucementViewModel
                          {
                              annoucementId = annoucement.annoucementId,
                              description = annoucement.description,
                              expireDate = annoucement.expireDate,
                              sectionNo = section.SectionNo,
                              sectionId = section.SectionID,
                              CourseName = course.CourseName
                          }).ToList();

            return result;
        }
    }
}