using System;
using System.Collections.Generic;
using System.Text;

namespace AgileClassRoom.ViewModel
{
    public class SectionViewModel
    {
        public int SectionID { get; set; }
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public int SectionNo { get; set; }
        public int TeacherID { get; set; }
        public string teacherName { get; set; }
        public int CreatedBy { get; set; }
    }
}
