using AgileClassRoom.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgileClassRoom.Interface
{
    public interface IDashBoard
    {
        AdminDashboardViewModel GetAdminDashboard(int userid);
        TeacherDashBoardViewModel GetTeacherDashboard(int userid);
        StudentDashboardViewModel GetStudentDashboard(int userid);
        CoordinatorDashboardViewModel GetCoordinatorDashboard(int userid);
    }
}
