namespace CarServiceBooking.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public int UserId { get; set; }
        public int ServiceId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; }
    }
}
