using System;
using System.Collections.Generic;
using System.Text;

namespace AgileClassRoom.ViewModel
{
    public class AssessmentViewModel
    {
        public int assessmentId { get; set; }
        public string assessmentName { get; set; }
        public int totalMarks { get; set; }
        public DateTime CreatedDate { get; set; }
        public int createdBy { get; set; }

    }
}
