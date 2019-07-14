using System;
using System.Collections.Generic;
using System.Text;

namespace AgileClassRoom.ViewModel
{
    public class RegisteredStudentViewModel
    {
       
        public string FullName { get; set; }
      
        public string EmailId { get; set; }
   
        public string Contactno { get; set; }
        
        public string CourseName { get; set; }
        public int SectionNo { get; set; }
          
        public decimal Cgpa { get; set; }
        public int Semester { get; set; }
        public int CreatedBy { get; set; }
    }
}
