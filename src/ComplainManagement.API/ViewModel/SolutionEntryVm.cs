using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplainManagement.API.ViewModel
{
    public class SolutionEntryVm
    {
        public string ComplainID { get; set; }
        public string CustomerName { get; set; }
        public string Mobile { get; set; }
        public int ComplainTypeId { get; set; }
        public string SolutionDetails { get; set; }
    }
}
