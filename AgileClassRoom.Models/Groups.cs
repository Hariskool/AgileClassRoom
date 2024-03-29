﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AgileClassRoom.Models
{
    [Table("Groups")]
    public class Groups
    {
        [Key]
        public int groupId { get; set; }
        public int groupNo { get; set; }
        public int totalMember { get; set; }
        public int sectionId { get; set; }
        public int createdBy { get; set; }

    }
}