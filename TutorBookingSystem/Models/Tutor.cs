using System.ComponentModel.DataAnnotations.Schema;

namespace TutorBookingSystem.Models
{
    public class Tutor
    {
        public int TutorId { get; set; }
        public string Bio { get; set; }
        public double RatesPerHour { get; set; }

        public int UserId { get; set; }

        //Navigation properties are user to show relationships between entities.
        public User User { get; set; }
        public Review Review { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<Subject> Subjects {get; set;}
        public ICollection<Qualification> Qualifications { get; set; }
    }
}
