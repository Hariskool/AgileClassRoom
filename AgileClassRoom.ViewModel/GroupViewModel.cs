using AgileClassRoom.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgileClassRoom.ViewModel
{
    public class GroupViewModel
    {
        public int groupId { get; set; }
        public int groupNo { get; set; }
        public int totalMember { get; set; }
        public int sectionId { get; set; }
        public int createdBy { get; set; }
        public IEnumerable<GroupMembers>groupMembers { get; set; }
    }
}
