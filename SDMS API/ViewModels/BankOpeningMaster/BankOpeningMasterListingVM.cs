using SDMS_API.ViewModels.BankOpeningDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.ViewModels.BankOpeningMaster
{
    public class BankOpeningMasterListingVM
    {
        public int Id { get; set; }
        public string VoucherNumber { get; set; }
        public DateTime Date { get; set; }
        public string PostStatus { get; set; }
        public IEnumerable<BankOpeningDetailListingVM> BankOpeningDetails { get; set; }
    }
}
