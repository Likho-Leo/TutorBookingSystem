namespace TutorBookingSystem.Models
{
    public class Qualification
    {
        public int QualificationId { get; set; }
        public string QualificationName { get; set; }

        //Nav properties
        public ICollection<Tutor> Tutors { get; set; }
    }
}
