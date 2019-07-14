using AgileClassRoom.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgileClassRoom.ViewModel
{
    public class GroupsViewModel
    {
        public Groups group { get; set; }
        public GroupMembers[] groupMembers { get; set; }

    }
}
