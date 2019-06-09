using AgileClassRoom.Models;
using AgileClassRoom.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgileClassRoom.Interface
{
    public interface IStudent
    {
        void InsertStudent(Student student);
        bool CheckStudentExits(string studentEmail);
        StudentViewModel GetStudentbyId(int StudentId);
        bool DeleteStudent(int studentId);
        bool UpdateStudent(Student student);
        List<StudentViewModel> GetAllStudent(int userId);
    }
}
