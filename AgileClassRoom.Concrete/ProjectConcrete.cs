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
   public class ProjectConcrete : IProject
    {
        private readonly DatabaseContext _context;
        private readonly IConfiguration _configuration;

        public ProjectConcrete(DatabaseContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public void InsertProject(Project project)
        {
            _context.Project.Add(project);
            _context.SaveChanges();

        }
        public bool CheckProjectExits(string projectName)
        {
            var result = (from project in _context.Project
                          where project.name == projectName

                          select project).Count();
            //
            return result > 0 ? true : false;
        }

        public ProjectViewModel GetProjectbyId(int projectId)
        {
            var result = (from project in _context.Project
                          join assessmetn in _context.Assessment on project.assessmentId equals assessmetn.assessmentId
                          where project.projectId == projectId
                          select new ProjectViewModel
                          {
                              projectId=project.projectId,
                              IssueDate=project.IssueDate,
                              EndDate=project.EndDate,
                              description=project.description,
                              name=project.name,
                              status=project.status,
                              assessmentId=assessmetn.assessmentId,
                              assessmentName=assessmetn.assessmentName
                          }).FirstOrDefault();

            return result;
        }
        public bool DeleteProject(int projectId)
        {
            var delresult = (from project in _context.Project
                             where project.projectId == projectId
                             select project).FirstOrDefault();

            if (delresult != null)
            {
                _context.Project.Remove(delresult);


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

        public bool UpdateProject(Project project)
        {

            _context.Entry(project).Property(x => x.name).IsModified = true;
            _context.Entry(project).Property(x => x.status).IsModified = true;
            _context.Entry(project).Property(x => x.assessmentId).IsModified = true;
            _context.Entry(project).Property(x => x.EndDate).IsModified = true;
            _context.Entry(project).Property(x => x.description).IsModified = true;
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
        public List<ProjectViewModel> GetAllProjects(int userId)
        {
            var findUser = (from teacher in _context.Teacher
                            join user in _context.Users on teacher.UserID equals user.UserId
                            where user.UserId == userId
                            select teacher.TeacherID).FirstOrDefault();
            int techId = Convert.ToInt32(findUser);

            var result = (from project in _context.Project
                          join assessmetn in _context.Assessment on project.assessmentId equals assessmetn.assessmentId
                          where project.createdBy == techId
                          select new ProjectViewModel
                          {
                              projectId = project.projectId,
                              IssueDate = project.IssueDate,
                              EndDate = project.EndDate,
                              description = project.description,
                              name = project.name,
                              status = project.status,
                              assessmentId = assessmetn.assessmentId,
                              assessmentName = assessmetn.assessmentName
                          }).ToList();

            return result;
        }
    }
}