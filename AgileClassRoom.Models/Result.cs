using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AgileClassRoom.Models
{
    [Table("Result")]
    public class Result
    {
        [Key]
        public int resultId { get; set; }
        public float obtainMarks { get; set; }
        public int occurenceId { get; set; }
        public int studentId { get; set; }
    }
}
