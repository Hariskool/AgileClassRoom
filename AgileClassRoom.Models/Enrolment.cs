using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AgileClassRoom.Models
{
    [Table("Enrolment")]
    public class Enrolment
    {
        [Key]
        public int EnrolmentID { get; set; }
        public int SectionID { get; set; }

        public int StudentID { get; set; }
        public int CreatedBy { get; set; }

    }
}
