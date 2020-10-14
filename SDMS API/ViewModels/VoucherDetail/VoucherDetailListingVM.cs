using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.ViewModels.VoucherDetail
{
    public class VoucherDetailListingVM
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string VendorName { get; set; }
        public string AccountName { get; set; }
        public string FlagDC { get; set; }
        public decimal Amount { get; set; }
        public string Remarks { get; set; }
    }
}
