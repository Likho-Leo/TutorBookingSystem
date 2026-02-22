using System.ComponentModel.DataAnnotations.Schema;

namespace TutorBookingSystem.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }

        public int TutorId { get; set; }
        public int UserId { get; set; }

        //Nav properties
        public User User { get; set; }
        public Tutor Tutor { get; set; }
        
    }
}
