using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace socialNet.Dtos.RequestDtos
{
    public class UpdateUserRequestDto
    {
        [Display(Name = "FirstName")]
        [Required(ErrorMessage = "The {0} field is mandatory.")]
        public string FirstName { get; set; }

        [Display(Name = "LastName")]
        [Required(ErrorMessage = "The {0} field is mandatory.")]
        public string LastName { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "The {0} field is mandatory.")]
        [StringLength(16, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 8)]
        [RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$",
            ErrorMessage = "The {0} must contain at 3 of 4 of the following: upper case (A-Z), lower case (a-z), number (0-9) and special character (e.g. !@#$%^&*).")]
        public string Password { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "The {0} field is mandatory.")]
        [EmailAddress(ErrorMessage = "Incorrect email address.")]
        public string Email { get; set; }

        [Display(Name = "City")]
        [Required(ErrorMessage = "The {0} field is mandatory.")]
        public string City { get; set; }

        [Display(Name = "Username")]
        [Required(ErrorMessage = "The {0} field is mandatory.")]
        public string Username { get; set; }
    }
}
