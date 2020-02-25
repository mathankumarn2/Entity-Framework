using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OnlineCollegeAdmission.Entity
{
    public class User
    {


        public int UserId { get; set; }

        [DisplayName("First Name")]
        [Required(ErrorMessage = "please enter Your Name")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Please enter valid name")]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "please enter Your LastName")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Please enter valid name")]
        [MaxLength(20)]
        public string LastName { get; set; }

        [DisplayName("Gender")]
        [Required(ErrorMessage = "please Select Gender")]
        public string Gender { get; set; }

        [DisplayName("Date Of Birth")]
        [Required(ErrorMessage = "please enter Your DOB")]
        [DataType(DataType.Date)]
        public DateTime Dob { get; set; }

        [DisplayName("Email Id")]
        [Required(ErrorMessage = "please enter Your Email Id")]
        [EmailAddress(ErrorMessage = "Please enter valid mail")]
        [DataType(DataType.EmailAddress)]
        public string EmailId { get; set; }

        [DisplayName("Mobile Number")]
        [Required(ErrorMessage = "please enter Your Phone Number")]
        [RegularExpression(@"^\+?\d{0,2}\-?\d{4,5}\-?\d{5,6}", ErrorMessage = "Please enter your number")]
        [DataType(DataType.PhoneNumber)]
        public long PhoneNumber { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "please enter Password")]
        [RegularExpression("^(?=.{8,})(?=.*[a-z])(?=.*[A-Z])(?!.*s).*$", ErrorMessage = "Please enter valid password like uppercase,lowecase,symbol and number")]
        [MinLength(8, ErrorMessage = "Password should atleast contain 8 characters")]
        public string Password { get; set; }

        [DisplayName("Confirm Password")]
        [Required(ErrorMessage = "please enter Password")]
        [RegularExpression("^(?=.{8,})(?=.*[a-z])(?=.*[A-Z])(?!.*s).*$", ErrorMessage = "Please enter valid password like uppercase,lowecase,symbol and number")]
        [MinLength(8, ErrorMessage = "Password should atleast contain 8 characters")]
        public string ConfirmPassword { get; set; }
        public string Role { get; set; }
        public User()
        {

        }
    }
}
