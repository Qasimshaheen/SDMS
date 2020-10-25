using SDMS_API.ViewModels.PurchaseDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.ViewModels.PurchaseMaster
{
    public class PurchaseListingVM
    {
        public int Id { get; set; }
        public string VendorName { get; set; }
        public string WarehouseName { get; set; }
        public DateTime Date { get; set; }
        public string BatchNo { get; set; }
        public string Remarks { get; set; }
        public string PostStatus { get; set; }
        public string VoucherNumber { get; set; }
        public IEnumerable<PurchaseDetailListingVM> PurchaseDetails { get; set; }
    }
}
