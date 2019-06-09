using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using AgileClassRoom.Interface;
using AgileClassRoom.Models;
using AgileClassRoom.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgileClassRoom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageNotificationController : ControllerBase
    {
        private readonly INotification _notification;

        public ManageNotificationController(INotification notification)
        {
            _notification = notification;
        }
        [HttpGet]
        public IEnumerable<Notification> Get()
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.Name);
                int uId = int.Parse(userId);
                return _notification.GetAllNotification(uId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public HttpResponseMessage Post([FromBody] NotificationViewModel notificationViewModel)
        {

            try
            {
                if (ModelState.IsValid)
                {

                    var userId = this.User.FindFirstValue(ClaimTypes.Name);
                    int uId = int.Parse(userId);
                    var tempNotification= AutoMapper.Mapper.Map<Notification>(notificationViewModel);
                    tempNotification.UserId = uId;
                 _notification.InsertNotification(tempNotification);

                        var response = new HttpResponseMessage()
                        {
                            StatusCode = HttpStatusCode.OK
                        };

                        return response;
                    }
                
                else
                {
                    var response = new HttpResponseMessage()
                    {

                        StatusCode = HttpStatusCode.BadRequest
                    };

                    return response;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}