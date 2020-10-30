using SDMS_API.ViewModels.PurchaseDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.ViewModels.PurchaseMaster
{
    public class PurchaseMasterDetailVM
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string VendorName { get; set; }
        public string WarehouseName { get; set; }
        public string VoucherNumber { get; set; }
        public DateTime Date { get; set; }
        public string BatchNo { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DiscountPerc { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal NetAmount { get; set; }
        public string Remarks { get; set; }
        public string PostStatus { get; set; }
        public IEnumerable<PurchaseDetailDetailVM> PurchaseDetails { get; set; }
    }
}
