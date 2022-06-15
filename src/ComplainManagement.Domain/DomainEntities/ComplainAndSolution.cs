using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplainManagement.Domain.DomainEntities
{
   public class ComplainAndSolution
    {

        [Key]
        public int ComplainId { get; set; }
        [Required]
        [MaxLength(200)]
        public string CustomerName { get; set; }
        [Required]
        [MaxLength(20)]
        public string CustomerMobile { get; set; }

        [Required]
        [StringLength(int.MaxValue)]
        public string ComplainDetails { get; set; }

        [Required]
        [MaxLength(20)]
        public string ComplainStatus { get; set; }

        [Required]
        [StringLength(int.MaxValue)]
        public string Solution { get; set; }


        public virtual ComplainType ComplainType { get; set; }
        public int ComplainTypeRef { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModifiedOn { get; set; }
    }
}
