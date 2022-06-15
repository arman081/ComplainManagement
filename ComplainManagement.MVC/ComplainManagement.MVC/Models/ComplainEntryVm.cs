using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComplainManagement.MVC.Models
{
    public class ComplainEntryVm
    {
        [Key]
        public int ComplainId { get; set; }
        [Required]
        [MaxLength(100)]
        public string CustomerName { get; set; }
        [Required]
        [MaxLength(20)]
        public string CustomerMobile { get; set; }

        [Required]
        [StringLength(int.MaxValue)]
        public string ComplainDetails { get; set; }
        public virtual ComplainType ComplainType { get; set; }
        public int ComplainTypeId { get; set; }

    }
}
