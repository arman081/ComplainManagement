using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComplainManagement.Domain.DomainEntities
{
    public class ComplainManagementUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserEmail { get; set; }
        public bool IsActive { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModifiedOn { get; set; }

    }
}
