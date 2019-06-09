using AgileClassRoom.Models;
using AgileClassRoom.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgileClassRoom.Interface
{
    public interface ICoordinator
    {
        void InsertCoordinator(Coordinator coordinator);
        bool CheckCoordinatorExits(string coordinatorEmail);
        CoordinatorViewModel GetCoordinatorbyId(int CoordinatorId);
        bool DeleteCoordinator(int coordinatorId);
        bool UpdateCoordinator(Coordinator coordinator);
        List<CoordinatorViewModel> GetAllCoordinator();
        int GetCoordinatorId(int id);
        int GetCoordinatorDepartmentId(int id);
    }
}
