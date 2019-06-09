using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AgileClassRoom.ViewModel
{
   public class DepartmentViewModel
    {
        [Required(ErrorMessage = "Enter Department name")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string DepartmentName { get; set; }
        public string Description { get; set; }
        public int? DepartmentId { get; set; }
    }
}