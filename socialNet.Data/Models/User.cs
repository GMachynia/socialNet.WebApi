using System;
using System.ComponentModel.DataAnnotations;

namespace socialNet.Data.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string LastName { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public byte[] PasswordHash { get; set; }
        [Required]
        public byte[] PasswordSalt { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [StringLength(50)]
        public string City { get; set; }
        [Required]
        public bool VerificationStatus { get; set; }

    }
}
