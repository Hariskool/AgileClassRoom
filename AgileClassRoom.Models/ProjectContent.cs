using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AgileClassRoom.Models
{
    [Table("ProjectContent")]
    public class ProjectContent
    {
        [Key]
        public int projectContentId { get; set; }
        public string mediaTitle { get; set; }
        public string mediaName { get; set; }

    }
}
