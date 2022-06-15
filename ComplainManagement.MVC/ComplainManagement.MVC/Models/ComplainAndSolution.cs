using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplainManagement.MVC.Models
{
   public class ComplainAndSolution
    {

        [Key]
        public int ComplainId { get; set; }
       
        [MaxLength(20)]
        [Display(Name = "Complain ID")]
        public string ComplainNo { get; set; }
        [Required]
        [MaxLength(200)]
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }
        [Required]
        [MaxLength(20)]
        [Display(Name = "Mobile")]
        public string CustomerMobile { get; set; }

        [Required]
        [StringLength(int.MaxValue)]
        [Display(Name = "Complain Details")]
        public string ComplainDetails { get; set; }

        
        [MaxLength(20)]
        public string ComplainStatus { get; set; }

   
        [StringLength(int.MaxValue)]

        [Display(Name = "Solution Details")]
        public string Solution { get; set; }

        [Display(Name = "Complain Type")]
        public virtual ComplainType ComplainType { get; set; }
        
        public int ComplainTypeId { get; set; }
        [Display(Name = "Complained On")]
        public DateTime? ComplainDate { get; set; }
        [Display(Name = "Resolved On")]
        public DateTime? SolutionDate { get; set; }


    }
}
