using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.ViewModels.ChartOfAccount
{
    public class ChartOfAccountCreateVM
    {
        public string AccountCode { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public bool IsDebit { get; set; }
        public int? ParentAccountId { get; set; }
        public bool IsDetailAccount { get; set; }
        public bool IsActive { get; set; }
    }
}
