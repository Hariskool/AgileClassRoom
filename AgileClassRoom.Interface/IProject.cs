using AgileClassRoom.Models;
using AgileClassRoom.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgileClassRoom.Interface
{
    public interface IProject
    {
        void InsertProject(Project project);
        bool CheckProjectExits(string projectname);
        ProjectViewModel GetProjectbyId(int projectId);
        bool DeleteProject(int projectId);
        bool UpdateProject(Project project);
        List<ProjectViewModel> GetAllProjects(int userId);
    }
}
