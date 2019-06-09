using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AgileClassRoom.Models
{
    [Table("Teacher")]
    public class Teacher
    {
        [Key]
        public int TeacherID { get; set; }
        public int DepartmentId { get; set; }
        public int UserID { get; set; }
        public int CreatedBy { get; set; }
    }
}
