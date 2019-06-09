using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AgileClassRoom.Models
{
    [Table("Student")]
    public class Student
    {
        [Key]
        public int StudentID { get; set; }
        public int UserID { get; set; }
        public int DepartmentID { get; set; }
        public decimal Cgpa { get; set; }
        public int Semester { get; set; }
        public int CreatedBy { get; set; }
    }
}
