using System;
using System.Collections.Generic;
using System.Text;

namespace AgileClassRoom.ViewModel
{
    public class AssessmentOccurenceViewModel
    {
        public int assessmentOccurenceId { get; set; }
        public string description { get; set; }
        public DateTime? occurenceDate { get; set; }
        public int assessmentId { get; set; }
        public string assessmentName { get; set; }
        public int createdBy { get; set; }
    }
}
