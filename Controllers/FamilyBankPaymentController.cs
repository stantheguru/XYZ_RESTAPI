using XYZ.DBOperations;
using XYZ.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace XYZ.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FamilyBankPaymentController : ControllerBase
    {
        private readonly DBContext DBContext;
        private int payment_id;
        private int student_id;
        private float amount;
        private DateTime payment_date;
        private string bank_channel;
        private string notif_channel;
        private string payment_method;

        public FamilyBankPaymentController(DBContext DBContext)
        {
            this.DBContext = DBContext;
        }

        //List all payments
        [HttpGet("GetPayments")]
        public async Task<ActionResult<List<DBFamilyBank_Payment>>> Get()
        {
            var List = await DBContext.FamilyBank_Payments.Select(
                payment => new DBFamilyBank_Payment
                {
                    PaymentID = payment.PaymentID,
                    StudentID = payment.StudentID,
                    Amount = payment.Amount,
                    PaymentDate = payment.PaymentDate,
                    PaymentMethod = payment.PaymentMethod,
                    BankChannel = payment.BankChannel,
                    NotificationChannel = payment.NotificationChannel
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
        //Select a specific payment
        [HttpGet("GetPaymentById")]
        public async Task<ActionResult<DBFamilyBank_Payment>> GetPaymentById(int Id)
        {
            DBFamilyBank_Payment FamilyBank_Payment = await DBContext.FamilyBank_Payments.Select(
                      payment => new DBFamilyBank_Payment
                      {
                          PaymentID = payment.PaymentID,
                          StudentID = payment.StudentID,
                          Amount = payment.Amount,
                          PaymentDate = payment.PaymentDate,
                          PaymentMethod = payment.PaymentMethod,
                          BankChannel = payment.BankChannel,
                          NotificationChannel = payment.NotificationChannel
                      })
                 .FirstOrDefaultAsync(payment => payment.PaymentID == Id);

            if (FamilyBank_Payment == null)
            {
                return NotFound();
            }
            else
            {
                return FamilyBank_Payment;
            }
        }
        //Insert Family bank payment then insert the payment into the XYZ Payment table. Finally create a notification record
        [HttpPost("InsertPayment")]
        public async Task<HttpStatusCode> InsertPayment(DBFamilyBank_Payment FamilyBank_Payment)
        {
            var entity = new FamilyBank_Payment()

            {
                PaymentID = FamilyBank_Payment.PaymentID,
                StudentID = FamilyBank_Payment.StudentID,
                Amount = FamilyBank_Payment.Amount,
                PaymentDate = FamilyBank_Payment.PaymentDate,
                PaymentMethod = FamilyBank_Payment.PaymentMethod,
                BankChannel = FamilyBank_Payment.BankChannel,
                NotificationChannel = FamilyBank_Payment.NotificationChannel
            };

            payment_id = FamilyBank_Payment.PaymentID;
            student_id = FamilyBank_Payment.StudentID;
            amount = FamilyBank_Payment.Amount;
            payment_date = FamilyBank_Payment.PaymentDate;
            payment_method = FamilyBank_Payment.PaymentMethod;
            bank_channel = FamilyBank_Payment.BankChannel;
            notif_channel = FamilyBank_Payment.NotificationChannel;

            //Filter student id before saving the payment record

            DBStudent Student = await DBContext.Students.Select(
                    student => new DBStudent
                    {
                        StudentID = student.StudentID,
                        
                    })
                .FirstOrDefaultAsync(student => student.StudentID == student_id);

            if (Student == null)
            {
                return HttpStatusCode.NotFound;  
            }
            else
            {
                DBContext.FamilyBank_Payments.Add(entity);
                await DBContext.SaveChangesAsync();

                var ent = new XYZ_Payment()
                {
                    PaymentID = payment_id,
                    StudentID = student_id,
                    Amount = amount,
                    PaymentDate = payment_date,
                    PaymentMethod = payment_method,
                    BankChannel = bank_channel,
                    NotificationChannel = notif_channel

                };

                DBContext.XYZ_Payments.Add(ent);
                await DBContext.SaveChangesAsync();

                var notification_entity = new Notification()
                {

                    StudentID = student_id,
                    PaymentID = payment_id,
                    NotificationDate = payment_date,
                    Status = "Sent",
                };

                DBContext.Notifications.Add(notification_entity);
                await DBContext.SaveChangesAsync();

            }

            return HttpStatusCode.Created;
        }
        //update payment
        [HttpPut("UpdatePayment")]
        public async Task<HttpStatusCode> UpdatePayment(DBFamilyBank_Payment FamilyBank_Payment)
        {
            var entity = await DBContext.FamilyBank_Payments.FirstOrDefaultAsync(payment => payment.PaymentID == FamilyBank_Payment.PaymentID);

            entity.PaymentID = FamilyBank_Payment.PaymentID;
            entity.StudentID = FamilyBank_Payment.StudentID;
            entity.Amount = FamilyBank_Payment.Amount;
            entity.PaymentDate = FamilyBank_Payment.PaymentDate;
            entity.PaymentMethod = FamilyBank_Payment.PaymentMethod;
            entity.BankChannel = FamilyBank_Payment.BankChannel;
            entity.NotificationChannel = FamilyBank_Payment.NotificationChannel;


            await DBContext.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
        //delete payment
        [HttpDelete("DeletePayment/{Id}")]
        public async Task<HttpStatusCode> DeletePayment(int Id)
        {
            var entity = new FamilyBank_Payment()
            {
                PaymentID = Id
            };
            DBContext.FamilyBank_Payments.Attach(entity);
            DBContext.FamilyBank_Payments.Remove(entity);
            await DBContext.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
    }
}
