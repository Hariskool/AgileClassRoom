using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AgileClassRoom.Models
{
    public class Notification
    {
        [Key]
        public int NotificationId { get; set; }
        public string Message { get; set; }
        public DateTime Createddate { get; set; }
        public int UserId { get; set; }
    }
}
