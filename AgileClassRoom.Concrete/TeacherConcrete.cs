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
   public class TeacherConcrete : ITeacher
    {
        private readonly DatabaseContext _context;
        private readonly IConfiguration _configuration;

        public TeacherConcrete(DatabaseContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public void InsertTeacher(Teacher teacher)
        {
            _context.Teacher.Add(teacher);
            _context.SaveChanges();

        }
        public bool CheckTeacherExits(string teacherEmail)
        {
            var result = (from teacher in _context.Teacher
                          join u in _context.Users on teacher.UserID equals u.UserId
                          where u.EmailId == teacherEmail
                          select teacher).Count();

            return result > 0 ? true : false;
        }

        public TeacherViewModel GetTeacherbyId(int teacherid)
        {
            var result = (from teacher in _context.Teacher
                          join user in _context.Users on teacher.UserID equals user.UserId
                          join department in _context.Department on teacher.DepartmentId equals department.DepartmentId
                          where teacher.TeacherID == teacherid

                          select new TeacherViewModel
                          {
                              TeacherId = teacher.TeacherID,
                              UserId = user.UserId,
                              UserName = user.UserName,
                              FullName = user.FullName,
                              EmailId = user.EmailId,
                              Contactno = user.Contactno,
                              Status = user.Status,
                              Password = EncodingLib.DecryptText(user.Password),
                              DepartmentId = department.DepartmentId,
                              DepartmentName = department.DepartmentName
                          }).FirstOrDefault();

            return result;
        }
        public bool DeleteTeacher(int teacherId)
        {
            var teacher = (from teachers in _context.Teacher
                               where teachers.TeacherID == teacherId
                               select teachers).FirstOrDefault();
            var user = (from users in _context.Users
                        join teachers in _context.Teacher on users.UserId equals teachers.UserID
                        where teachers.TeacherID == teacherId
                        select users).FirstOrDefault();
            if (teacher != null)
            {
                _context.Teacher.Remove(teacher);
                _context.Users.Remove(user);

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

        public bool UpdateTeacher(Teacher teacher)
        {

            _context.Entry(teacher).Property(x => x.DepartmentId).IsModified = true;
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
        public int GetTeacherId(int id)
        {
            var result = (from teacher in _context.Teacher
                          where teacher.UserID == id
                          select teacher.TeacherID).FirstOrDefault();
            return Convert.ToInt32(result);

        }
       public List<TeacherViewModel> GetAllTeachersOfCoordinator(int id)
        {
            var result = (from teacher in _context.Teacher
                          join user in _context.Users on teacher.UserID equals user.UserId
                          join department in _context.Department on teacher.DepartmentId equals department.DepartmentId
                          where teacher.CreatedBy == id
                          select new TeacherViewModel
                          {
                              TeacherId = teacher.TeacherID,
                              UserId = user.UserId,
                              UserName = user.UserName,
                              FullName = user.FullName,
                              EmailId = user.EmailId,
                              Contactno = user.Contactno,
                              Status = user.Status,
                              Password = EncodingLib.DecryptText(user.Password),
                              DepartmentId = department.DepartmentId,
                              DepartmentName = department.DepartmentName
                          }
).ToList();

            return result;
        }
        public List<TeacherViewModel> GetAllTeacher(int userId)
        {
            var findUser = (from coordinator in _context.Coordinator
                            join user in _context.Users on coordinator.UserId equals user.UserId
                            where user.UserId == userId
                            select coordinator.CoordinatorId).FirstOrDefault();
            int coorId = Convert.ToInt32(findUser);

            var result = (from teacher in _context.Teacher
                          join user in _context.Users on teacher.UserID equals user.UserId
                          join department in _context.Department on teacher.DepartmentId equals department.DepartmentId
                          where teacher.CreatedBy == coorId
                          select new TeacherViewModel
                          {
                              TeacherId = teacher.TeacherID,
                              UserId = user.UserId,
                              UserName = user.UserName,
                              FullName = user.FullName,
                              EmailId = user.EmailId,
                              Contactno = user.Contactno,
                              Status = user.Status,
                              Password = EncodingLib.DecryptText(user.Password),
                              DepartmentId = department.DepartmentId,
                              DepartmentName = department.DepartmentName
                          }
                          ).ToList();

            return result;
        }
    }
}
