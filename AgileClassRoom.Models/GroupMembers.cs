using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AgileClassRoom.Models
{
    [Table("GroupMembers")]
   public class GroupMembers
    {
        [Key]
        public int groupMemberId { get; set; }
        public int studentId { get; set; }
        public int groupId { get; set; }

    }
}
