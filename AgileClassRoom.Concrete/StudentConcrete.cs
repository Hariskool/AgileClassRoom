using AgileClassRoom.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AgileClassRoom.ViewModel;
using AgileClassRoom.Interface;

namespace AgileClassRoom.Concrete
{
    public class StudentConcrete: IStudent
    {
        private readonly DatabaseContext _context;
        private readonly IConfiguration _configuration;

        public StudentConcrete(DatabaseContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public void InsertStudent(Student student)
        {
            _context.Student.Add(student);
            _context.SaveChanges();

        }
        public bool CheckStudentExits(string studentEmail)
        {
            var result = (from student in _context.Student
                          join u in _context.Users on student.UserID equals u.UserId
                          where u.EmailId == studentEmail
                          select student).Count();

            return result > 0 ? true : false;
        }
        public StudentViewModel GetStudentbyId(int studentid)
        {
            var result = (from student in _context.Student
                          join user in _context.Users on student.UserID equals user.UserId
                          join department in _context.Department on student.DepartmentID equals department.DepartmentId
                          where student.StudentID == studentid

                          select new StudentViewModel
                          {
                              StudentId = student.StudentID,
                              Cgpa = student.Cgpa,
                              Semester = student.Semester,
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
        public bool DeleteStudent (int studentId)
        {
            var student = (from students in _context.Student
                           where students.StudentID == studentId
                           select students).FirstOrDefault();
            var user = (from users in _context.Users
                        join students in _context.Student on users.UserId equals students.UserID
                        where student.StudentID == studentId
                        select users).FirstOrDefault();
            if (student != null)
            {
                _context.Student.Remove(student);
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
        public bool UpdateStudent(Student student)
        {

            _context.Entry(student).Property(x => x.DepartmentID).IsModified = true;
            _context.Entry(student).Property(x => x.Cgpa).IsModified = true;
            _context.Entry(student).Property(x => x.Semester).IsModified = true;
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
        public int GetStudentId(int id)
        {
            var result = (from student in _context.Student
                          where student.UserID == id
                          select student.StudentID).FirstOrDefault();
            return Convert.ToInt32(result);

        }
        public List<StudentViewModel> GetAllStudent(int userId)
        {
            var findUser = (from coordinator in _context.Coordinator
                            join user in _context.Users on coordinator.UserId equals user.UserId
                            where user.UserId == userId
                            select coordinator.CoordinatorId).FirstOrDefault();
            int coorId = Convert.ToInt32(findUser);

            var result = (from student in _context.Student
                          join user in _context.Users on student.UserID equals user.UserId
                          join department in _context.Department on student.DepartmentID equals department.DepartmentId
                          where student.CreatedBy == coorId
                          select new StudentViewModel
                          {
                              StudentId = student.StudentID,
                              Cgpa=student.Cgpa,
                              Semester=student.Semester,
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