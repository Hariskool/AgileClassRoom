using AgileClassRoom.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgileClassRoom.Interface
{
   public interface IGroupMember
    {
        void InsertGroupMembers(GroupMembers group);
        bool CheckGroupMembersExits(int groupMemberId);
        bool DeleteGroupMembers(int groupMemberId);
        bool UpdateGroup(GroupMembers group);
    }
}
