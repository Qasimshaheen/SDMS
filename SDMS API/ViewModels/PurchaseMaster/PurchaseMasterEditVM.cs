using SDMS_API.ViewModels.PurchaseDetail;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.ViewModels.PurchaseMaster
{
    public class PurchaseMasterEditVM
    {
        public int Id { get; set; }
        public int VendorId { get; set; }
        public int WarehouseId { get; set; }
        public DateTime Date { get; set; }
        [StringLength(50)]
        public string BatchNo { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DiscountPerc { get; set; }
        public decimal DiscountAmount { get; set; }
        [StringLength(100)]
        public string Remarks { get; set; }
        public bool IsPosted { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public IEnumerable<PurchaseDetailEditVM> PurchaseDetails { get; set; }
    }
}
