using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AgileClassRoom.Models
{
    [Table("Section")]
    public class Section
    {
        [Key]
        public int SectionID { get; set;}
        public int CourseID { get; set; }
        public int SectionNo { get; set; }
        public int TeacherID { get; set; }
        public int CreatedBy { get; set; }

    }
}
