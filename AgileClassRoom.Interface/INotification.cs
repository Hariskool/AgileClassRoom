using AgileClassRoom.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgileClassRoom.Interface
{
   public interface INotification
    {
        void InsertNotification(Notification notification);
        List<Notification> GetAllNotification(int UserID);
    }
}
