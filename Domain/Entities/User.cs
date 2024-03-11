using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User
    {
        public Guid UserId { get; set; }
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string Login { get; set; }

        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; }

        public bool IsEmailConfirmed { get; set; } = false;

        public string? Token { get; set; }

        public IdentityRole Role { get; set; }


    }
}