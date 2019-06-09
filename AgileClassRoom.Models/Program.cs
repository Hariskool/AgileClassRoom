using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AgileClassRoom.Models
{
    [Table("Program")]
    public class Program
    {
        [Key]
        public int ProgramID { get; set; }
        [Required(ErrorMessage = "Please enter ProgramCode")]
        [MinLength(6, ErrorMessage = "cannot be less then 3")]
        [StringLength(8)]
        public string ProgramCode { get; set; }
        [Required(ErrorMessage = "Please enter CourseName")]
        [Range(1, 60, ErrorMessage = "Please enter between 1 to 60")]
        public string TotalCreditHours { get; set; }
        [Required(ErrorMessage = "Please enter ProgramName")]
        [StringLength(15)]
        public string ProgramName { get; set; }
        [Required(ErrorMessage = "Please enter coordinatorId")]
        public int CoordinatorId { get; set; }
    }
}
