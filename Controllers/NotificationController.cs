using XYZ.DBOperations;
using XYZ.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace XYZ.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly DBContext DBContext;

        public NotificationController(DBContext DBContext)
        {
            this.DBContext = DBContext;
        }

        //List all notifications
        [HttpGet("GetNotifications")]
        public async Task<ActionResult<List<DBNotification>>> Get()
        {
            var List = await DBContext.Notifications.Select(
                notification => new DBNotification
                {

                    
                    NotificationID = notification.NotificationID,
                    StudentID = notification.StudentID,
                    PaymentID = notification.PaymentID,
                    NotificationDate = notification.NotificationDate,
                    Status = notification.Status
                }
            ).ToListAsync();

            if (List.Count < 0)
            {
                return NotFound();
            }
            else
            {
                return List;
            }
        }
        //Select a specific  notification
        [HttpGet("GetNotificationByNotificationId")]
        public async Task<ActionResult<DBNotification>> GetNotificationByNotificationId(int notification_id)
        {
            DBNotification Notification = await DBContext.Notifications.Select(
                      notification => new DBNotification
                      {
                          NotificationID = notification.NotificationID,
                          StudentID = notification.StudentID,
                          PaymentID = notification.PaymentID,
                          NotificationDate = notification.NotificationDate,
                          Status = notification.Status
                      })
                 .FirstOrDefaultAsync(notification => notification.NotificationID == notification_id);

            if (Notification == null)
            {
                return NotFound();
            }
            else
            {
                return Notification;
            }
        }

        //update notification
        [HttpPut("UpdateNotification")]
        public async Task<HttpStatusCode> UpdateNotification(DBNotification Notification)
        {
            var entity = await DBContext.Notifications.FirstOrDefaultAsync(notification => notification.PaymentID == Notification.NotificationID);

            entity.NotificationID = Notification.NotificationID;
            entity.StudentID = Notification.StudentID;
            entity.PaymentID = Notification.PaymentID;
            entity.NotificationDate = Notification.NotificationDate;
            entity.Status = Notification.Status;


            await DBContext.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
        //delete notification
        [HttpDelete("DeleteNotification/{Id}")]
        public async Task<HttpStatusCode> DeleteNotification(int Id)
        {
            var entity = new Notification()
            {
                NotificationID = Id
            };
            DBContext.Notifications.Attach(entity);
            DBContext.Notifications.Remove(entity);
            await DBContext.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
    }
}
