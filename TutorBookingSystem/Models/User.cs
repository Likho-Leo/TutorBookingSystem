using Microsoft.AspNetCore.Identity;

namespace TutorBookingSystem.Models
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

        //Nav properties
        public Tutor Tutor { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
        public Review Review { get; set; }
    }
}
