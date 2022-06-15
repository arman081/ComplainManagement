using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplainManagement.API.ViewModel
{
    public class ComplainReportFilter
    {
        public int ComplainTypeId { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
    }
}
