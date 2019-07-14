using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AgileClassRoom.Models
{
    [Table("Project")]
    public class Project
    {
        [Key]
        public int projectId { get; set; }
        public string description { get; set; }
        public int status { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime EndDate { get; set; }
        public int assessmentId { get; set; }
        public int createdBy { get; set; }
        public string name { get; set; }
    }
}
