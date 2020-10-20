using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.Data
{
    public class PurchaseMaster
    {
        public int Id { get; set; }
        public int VendorId { get; set; }
        public int WarehouseId { get; set; }
        public int? VoucherMasterId { get; set; }
        [StringLength(20)]
        public string Code { get; set; }
        public DateTime Date { get; set; }
        [StringLength(50)]
        public string BatchNo { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DiscountPerc { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal NetAmount { get; set; }
        [StringLength(100)]
        public string Remarks { get; set; }
        public bool IsPosted { get; set; }
        [ForeignKey(nameof(TblAddedByUser))]
        public int AddedBy { get; set; }
        public User TblAddedByUser { get; set; }
        public DateTime AddedOn { get; set; }
        [ForeignKey(nameof(TblUpdatedByUser))]
        public int? UpdatedBy { get; set; }
        public User TblUpdatedByUser { get; set; }
        public DateTime? UpdatedOn { get; set; }
        [ForeignKey(nameof(VoucherMasterId))]
        public VoucherMaster TblVoucherMaster { get; set; }
        [ForeignKey(nameof(WarehouseId))]
        public Warehouse TblWarehouse { get; set; }
        [ForeignKey(nameof(VendorId))]
        public Vendor TblVendor { get; set; }
        public List<PurchaseDetail> PurchaseDetails { get; set; }
    }
}
