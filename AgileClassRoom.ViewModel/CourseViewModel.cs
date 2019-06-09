using System;
using System.Collections.Generic;
using System.Text;

namespace AgileClassRoom.ViewModel
{
    public class CourseViewModel
    {
        public int CourseID { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }    
        public int CreditHours { get; set; }     
        public int ProgramID { get; set; }
        public string ProgramInfo { get; set; }
        public int CreatedBy { get; set; }

        public string CoordinatorName { get; set; }
    }
}
