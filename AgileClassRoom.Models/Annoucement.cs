using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AgileClassRoom.Models
{
    [Table("Annoucement")]
    public class Annoucement
    {
        [Key]
        public int annoucementId { get; set; }
        public DateTime? expireDate { get; set; }
        public string description { get; set; }
        public int sectionId { get; set; }
        public int createdBy { get; set; }

    }
}
