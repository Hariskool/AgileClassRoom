using System;
using System.Collections.Generic;
using System.Text;

namespace AgileClassRoom.ViewModel
{
    public class NotificationViewModel
    {
        public int NotificationId { get; set; }
        public string Message { get; set; }
        public DateTime Createddate { get; set; }
        public int UserId { get; set; }
    }
}
