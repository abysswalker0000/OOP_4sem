using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Domain.DTO
{
    public class SignUpUserDto
    {
        [Required, EmailAddress]
        public required string Email { get; set; }

        [Required]
        public required string Password { get; set; }

        [Required, Compare(nameof(Password), ErrorMessage = "The passwords didn't match")]
        public required string ConfirmPassword { get; set; }
    }
}
