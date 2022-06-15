using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComplainManagement.MVC.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [MaxLength(200)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(200)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(200)]
        public string UserEmail { get; set; }
        [Required]
        [MaxLength(200)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(200)]
        public string Password { get; set; }
        [Required]
        [MaxLength(200)]
        public string ConfirmPassword { get; set; }

        [Required]
        [MaxLength(20)]
        public string UserType { get; set; } = "Admin";
    }
}
