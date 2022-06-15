using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ComplainManagement.Domain.DomainEntities
{
    public class ComplainManagementUser : IdentityUser
    {
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
        [MaxLength(20)]
        public string UserType { get; set; } = "Admin";
        [Required]
        public bool IsActive { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModifiedOn { get; set; }

    }
}
