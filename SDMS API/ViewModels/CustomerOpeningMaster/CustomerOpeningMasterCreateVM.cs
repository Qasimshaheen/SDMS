using SDMS_API.ViewModels.CustomerOpeningDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.ViewModels.CustomerOpeningMaster
{
    public class CustomerOpeningMasterCreateVM
    {
        public DateTime Date { get; set; }
        public bool IsPosted { get; set; }
        public IEnumerable<CustomerOpeningDetailCreateVM> CustomerOpeningDetails { get; set; }
    }
}
