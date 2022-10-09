using XYZ.DBOperations;
using XYZ.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace XYZ.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class XYZPaymentController : ControllerBase
    {
        private readonly DBContext DBContext;
        
        public XYZPaymentController(DBContext DBContext)
        {
            this.DBContext = DBContext;
        }

        //List all payments
        [HttpGet("GetPayments")]
        public async Task<ActionResult<List<DBXYZ_Payment>>> Get()
        {
            var List = await DBContext.XYZ_Payments.Select(
                payment => new DBXYZ_Payment
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
        //Select a specific  payment by Payment ID
        [HttpGet("GetPaymentById")]
        public async Task<ActionResult<DBXYZ_Payment>> GetPaymentById(int Id)
        {
            DBXYZ_Payment XYZ_Payment = await DBContext.XYZ_Payments.Select(
                      payment => new DBXYZ_Payment
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

            if (XYZ_Payment == null)
            {
                return NotFound();
            }
            else
            {
                return XYZ_Payment;
            }
        }

        


        //update payment
        [HttpPut("UpdatePayment")]
        public async Task<HttpStatusCode> UpdatePayment(DBXYZ_Payment XYZ_Payment)
        {
            var entity = await DBContext.XYZ_Payments.FirstOrDefaultAsync(payment => payment.PaymentID == XYZ_Payment.PaymentID);

            entity.PaymentID = XYZ_Payment.PaymentID;
            entity.StudentID = XYZ_Payment.StudentID;
            entity.Amount = XYZ_Payment.Amount;
            entity.PaymentDate = XYZ_Payment.PaymentDate;
            entity.PaymentMethod = XYZ_Payment.PaymentMethod;
            entity.BankChannel = XYZ_Payment.BankChannel;
            entity.NotificationChannel = XYZ_Payment.NotificationChannel;


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
