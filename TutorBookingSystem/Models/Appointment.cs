using System.ComponentModel.DataAnnotations.Schema;

namespace TutorBookingSystem.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Mode { get; set; }
        public DateTime CreatedAt { get; set; }

        
        public int UserId { get; set; }
        public int TutorId { get; set; }

        //nav properties
        public Tutor Tutor { get; set; }
        public User User { get; set; }
    }
}
