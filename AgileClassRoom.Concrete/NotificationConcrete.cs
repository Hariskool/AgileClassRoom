using AgileClassRoom.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace AgileClassRoom.Concrete
{
    public class NotificationConcrete
    {
        private readonly DatabaseContext _context;
        public NotificationConcrete(DatabaseContext context)
        {
            _context = context;
        }
        public void InsertNotification(Notification notification)
        {
            _context.Notification.Add(notification);
            _context.SaveChanges();
        }
       public List<Notification> GetAllNotification(int UserID)
        {
            var result = (from notification in _context.Notification
                          where notification.UserId== UserID
                          select notification).ToList();

            return result;
        }
    }
}
