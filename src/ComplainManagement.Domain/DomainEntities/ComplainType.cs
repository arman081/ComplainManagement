using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplainManagement.Domain.DomainEntities
{
    public class ComplainType
    {
        [Key]
        public int ComplainTypeId { get; set; }
        [MaxLength(100)]
        [Required]        
        public string ComplainTypeName { get; set; }
        [Required]
        public bool IsActive { get; set; } = true;
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public DateTime? LastModifiedOn { get; set; }

        public ComplainAndSolution ComplainAndSolution { get; set; }
    }
}
