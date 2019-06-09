using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AgileClassRoom.ViewModel
{
    public class CoordinatorViewModel
    {
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string EmailId { get; set; }
        [Required]
        public string Contactno { get; set; }
        [Required]
        public string Password { get; set; }
        public bool Status { get; set; }
        public int CoordinatorId { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}