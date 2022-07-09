using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace hw5.Models
{
    public class User
    {
        [Required(ErrorMessage = "→ Do you want us to call you the anonymous one?")]
        [MinLength(3, ErrorMessage = "Excuse me? Did you seriously settle for being called by something consisting of less than 3 letters?")]
        [DisplayName("Your Name: ")]
        public string FullName { get; set; }

        // Assumption: The country calling code is Turkey in this application.
        [Required(ErrorMessage = "→ Are we going to contact you through smoke signals?")]
        [MinLength(10, ErrorMessage = "→ Your phone number should consist of 10 digits without the calling code")]
        [MaxLength(10)]
        [DisplayName("Phone Number: ")]
        [Phone(ErrorMessage = "→ Please only enter numbers. Don't you give out your number to people much?")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "→ It shouldn't be challenging to give us an alternative option to contact you, should it?")]
        [EmailAddress(ErrorMessage = "→ What kind of an email type is this? Gosh, why would someone think of shining me on about this?")]
        [DisplayName("Email: ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "→ Could you do me a favor by selecting an option?")]
        [DisplayName("Gender: ")]
        public string Gender { get; set; }
    }
}
