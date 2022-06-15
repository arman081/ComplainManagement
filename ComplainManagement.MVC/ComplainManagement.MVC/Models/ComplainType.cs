using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComplainManagement.MVC.Models
{
    public class ComplainType
    {
        [Key]

        public int ComplainTypeId { get; set; }
        [MaxLength(100)]
        [Required]
        public string ComplainTypeName { get; set; }
    }
}
