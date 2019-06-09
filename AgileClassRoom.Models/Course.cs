using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AgileClassRoom.Models
{
    [Table("Course")]

    public class Course {

    [Key]
    public int CourseID { get; set; }
    [Required(ErrorMessage = "Please enter CourseCode")]
    [MaxLength(6, ErrorMessage = "cannot be less then 6")]
    [StringLength(8)]
    public string CourseCode { get; set; }
    [Required(ErrorMessage = "Please enter CourseName")]
    [StringLength(15)]
    public string CourseName { get; set; }
    [Required(ErrorMessage = "Please enter CourseName")]
    [Range(1, 3, ErrorMessage = "Please enter between 1 to 3")]
    public int CreditHours { get; set; }
    [Required(ErrorMessage = "ProgramID Required")]
    public int ProgramID { get; set; }
    public int CreatedBy { get; set; }

    }
}

  