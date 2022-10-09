
namespace XYZ.Models
{
    public partial class FamilyBank_Payment
    {
        public int PaymentID { get; set; } //Payment ID

        public int StudentID { get; set; } //Student ID

        public float Amount { get; set; } //Amount

        public DateTime PaymentDate { get; set; } //Payment Date


        public string PaymentMethod { get; set; } //Payment Method

        public string BankChannel { get; set; } //Bank Channel

        public string NotificationChannel { get; set; } //Notification Channel i.e sms/email
    }
}
