using AgileClassRoom.Models;
using AgileClassRoom.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgileClassRoom.Interface
{
    public interface IAssignProject
    {
        void InsertAssignProject(AssignProject assignProject);
        bool CheckAssignProjectExits(int projectId,int sectionId);
        AssignProjectViewModel GetAssignProjectbyId(int apId);
        List<CourseViewModel> GetTeacherCourses(int userId);
        List<SectionViewModel> GetTeacherSections(int userId, int courseId);
        bool DeleteAssignProject(int apId);
        bool UpdateAssignProject(AssignProject assignProject);
        List<AssignProjectViewModel> GetAllAssignProjects(int userId);
    }
}
