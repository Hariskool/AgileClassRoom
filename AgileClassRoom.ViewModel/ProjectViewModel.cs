using System;
using System.Collections.Generic;
using System.Text;

namespace AgileClassRoom.ViewModel
{
    public class ProjectViewModel
    {
        public int projectId { get; set; }
        public string description { get; set; }
        public int status { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime EndDate { get; set; }
        public int assessmentId { get; set; }
        public string assessmentName { get; set; }
        public string name { get; set; }
        public int createdBy { get; set; }
    }
}
