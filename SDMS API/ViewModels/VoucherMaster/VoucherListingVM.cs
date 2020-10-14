using SDMS_API.ViewModels.VoucherDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.ViewModels.VoucherMaster
{
    public class VoucherListingVM
    {
        public int Id { get; set; }
        public string VoucherNumber { get; set; }
        public decimal? TotalDebit { get; set; }
        public decimal? TotalCredit { get; set; }
        public string PostStatus { get; set; }
        public string CreatedBy { get; set; }
        public IEnumerable<VoucherDetailListingVM> VoucherDetails { get; set; }

    }
}
