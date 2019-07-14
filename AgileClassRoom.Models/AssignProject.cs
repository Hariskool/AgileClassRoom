using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AgileClassRoom.Models
{
    [Table("AssignProject")]
    public class AssignProject
    {
        [Key]
        public int assignProjectId { get; set; }
        public int courseId { get; set; }
        public int sectionId { get; set; }
        public int projectId { get; set; }
        public int createdBy { get; set; }
    }
}
