using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.ViewModels.ChartOfAccount
{
    public class ChartOfAccountListingVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AccountCode { get; set; }
        public string Category { get; set; }
    }
}
