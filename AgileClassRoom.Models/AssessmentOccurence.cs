using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AgileClassRoom.Models
{
    [Table("AssessmentOccurence")]
    public class AssessmentOccurence
    {
        [Key]
        public int assessmentOccurenceId { get; set; }
        public string description { get; set; }
        public DateTime? occurenceDate { get; set; }
        public int assessmentId { get; set; }
        public int createdBy { get; set; }
    }
}
