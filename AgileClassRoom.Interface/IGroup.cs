using AgileClassRoom.Models;
using AgileClassRoom.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgileClassRoom.Interface
{
   public interface IGroup
    {
        void InsertGroup(Groups group);
        bool CheckGroupExits(int groupNo);
        GroupViewModel GetGroupbyId(int groupNo);
        bool DeleteGroup(int groupNo);
        bool UpdateGroup(Groups course);
        List<GroupViewModel> GetAllGroups(int userId);
       
    }
}
