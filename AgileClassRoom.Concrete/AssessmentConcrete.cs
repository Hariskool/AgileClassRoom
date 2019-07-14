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
    public class AssessmentConcrete : IAssessment
    {
        private readonly DatabaseContext _context;
        private readonly IConfiguration _configuration;

        public AssessmentConcrete(DatabaseContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public void InsertAssessment(Assessment assessment)
        {
            _context.Assessment.Add(assessment);
            _context.SaveChanges();

        }
        public bool CheckAssessmentExits(string assessmentName)
        {
            var result = (from assessment in _context.Assessment
                          where assessment.assessmentName == assessmentName
                        
                          select assessment).Count();
            //
            return result > 0 ? true : false;
        }

        public AssessmentViewModel GetAssessmentbyId(int assessmentId)
        {
            var result = (from assessment in _context.Assessment


                          where assessment.assessmentId == assessmentId
                          select new AssessmentViewModel
                          {
                              assessmentId = assessment.assessmentId,
                              assessmentName = assessment.assessmentName,
                              createdBy = assessment.createdBy,
                              CreatedDate = assessment.createdDate,
                              totalMarks = assessment.totalMarks
                          }).FirstOrDefault();

            return result;
        }
        public bool DeleteAssessment(int assessmentId)
        {
            var delresult = (from assessment in _context.Assessment
                             where assessment.assessmentId == assessmentId
                             select assessment).FirstOrDefault();

            if (delresult != null)
            {
                _context.Assessment.Remove(delresult);


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

        public bool UpdateAssessment(Assessment assessment)
        {

            _context.Entry(assessment).Property(x => x.assessmentName).IsModified = true;
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
        public List<AssessmentViewModel> GetAllAssessments(int userId)
        {
            var findUser = (from teacher in _context.Teacher
                            join user in _context.Users on teacher.UserID equals user.UserId
                            where user.UserId == userId
                            select teacher.TeacherID).FirstOrDefault();
            int techId = Convert.ToInt32(findUser);

            var result = (from assessment in _context.Assessment
                  

                          where assessment.createdBy == techId
            
                          select new AssessmentViewModel
                          {
                              assessmentId=assessment.assessmentId,
                              assessmentName=assessment.assessmentName,
                              createdBy=assessment.createdBy,
                              CreatedDate=assessment.createdDate,
                              totalMarks=assessment.totalMarks
                          }).ToList();
            return result;
        }
    }
}