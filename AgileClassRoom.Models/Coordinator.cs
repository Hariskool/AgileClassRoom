using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AgileClassRoom.Models
{
    [Table("Coordinator")]
    public class Coordinator
    {
        [Key]
        public int CoordinatorId { get; set; }
        public int UserId { get; set; }
        public int DepartmentId { get; set; }
        
    }
}

