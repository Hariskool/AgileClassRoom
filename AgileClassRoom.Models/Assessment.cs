using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AgileClassRoom.Models
{
   
    [Table("Assessment")]
    public class Assessment
    {
        [Key]
        public int assessmentId { get; set; }
        public string assessmentName { get; set;}
        public int totalMarks { get; set; }
        public DateTime createdDate { get; set; }

        public int createdBy { get; set; }
 
        

    }
}
