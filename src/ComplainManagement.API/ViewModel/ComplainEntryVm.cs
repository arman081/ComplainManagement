using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplainManagement.API.ViewModel
{
    public class ComplainEntryVm
    {
        
        public string CustomerName { get; set; }
        public string CustomerMobile { get; set; }
        public int ComplainTypeId { get; set; }        
        public string ComplainDetails { get; set; }
    }
}
