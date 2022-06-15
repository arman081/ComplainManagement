using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplainManagement.API.ViewModel
{
    public class ComplainListFilterVm
    {
        public string ComplainID { get; set; }
        public string CustomerName { get; set; }
        public string Mobile { get; set; }
        public string ComplainType { get; set; }
        public string Status { get; set; }
        public string ComplainedOn { get; set; }
        public string ResolvedOn { get; set; }
    }
}
