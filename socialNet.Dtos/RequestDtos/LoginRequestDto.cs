using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace socialNet.Dtos.RequestDtos
{
    public class LoginRequestDto
    {
        [Display(Name = "Username")]
        [Required(ErrorMessage = "The {0} field is mandatory.")]
        public string Username { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "The {0} field is mandatory.")]
        public string Password { get; set; }
    }
}
