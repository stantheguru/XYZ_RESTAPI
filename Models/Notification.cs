
namespace XYZ.Models
{
    public partial class Notification
    {
        public int NotificationID { get; set; } //Notification ID

        public int StudentID { get; set; } //Student ID

        public int PaymentID { get; set; } //XYZ Payment
                                           //
        public DateTime NotificationDate { get; set; } //XYZ Payment ID

     
        public string Status { get; set; } //Status e.g Sent,Failed
    }
}
