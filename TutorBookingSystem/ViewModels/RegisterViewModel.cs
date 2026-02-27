using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace TutorBookingSystem.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "First name is requireed.")]
        [Display(Name ="First Name")]
        public String FirstName { get; set; }

        [Required(ErrorMessage = "Last name is requireed.")]
        [Display(Name = "Last Name")]
        public String LastName { get; set; }

        [Required(ErrorMessage = "Date of Birth is required.")]
        [Display(Name ="Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Date of Birth is required.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Date of Birth is required.")]
        public string Province { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(40, MinimumLength =8, ErrorMessage ="The {0} must be at {2} and at max {1} characters long.")]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword", ErrorMessage = "Password does not match.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password is required.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}
