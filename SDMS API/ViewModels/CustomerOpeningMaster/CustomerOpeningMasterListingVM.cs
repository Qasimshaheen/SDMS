using SDMS_API.ViewModels.CustomerOpeningDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.ViewModels.CustomerOpeningMaster
{
    public class CustomerOpeningMasterListingVM
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string VoucherNumber { get; set; }
        public string PostStatus { get; set; }
        public IEnumerable<CustomerOpeningDetailListingVM> CustomerOpeningDetails { get; set; }
    }
}
