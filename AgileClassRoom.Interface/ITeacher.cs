﻿using AgileClassRoom.Models;
using AgileClassRoom.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgileClassRoom.Interface
{
   public interface ITeacher
    {
        void InsertTeacher(Teacher teacher);
        bool CheckTeacherExits(string teacherEmail);
        TeacherViewModel GetTeacherbyId(int TeacherId);
        bool DeleteTeacher(int teacherId);
        bool UpdateTeacher(Teacher teacher);
        int GetTeacherId(int id);
      
        List<TeacherViewModel> GetAllTeacher(int userId);
        List<RegisteredStudentViewModel> GetAllStudentsOfTeacher(int userId);
        List<TeacherViewModel> GetAllTeachersOfCoordinator(int id);
    }
}
