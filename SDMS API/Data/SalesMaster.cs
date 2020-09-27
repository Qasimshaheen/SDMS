using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace SDMS_API.Data
{
    public class SalesMaster
    {
        public int Id { get; set; }
        public int? SOrderId { get; set; }
        public int? VoucherMasterId { get; set; }
        [StringLength(20)]
        public string Code { get; set; }
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
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
        [ForeignKey(nameof(CustomerId))]
        public Customer TblCustomer { get; set; }
        [ForeignKey(nameof(SOrderId))]
        public SOrderMaster TblSOrderMaster { get; set; }
        public List<SalesDetail> SalesDetails { get; set; }
        [ForeignKey(nameof(VoucherMasterId))]
        public VoucherMaster TblVoucherMaster { get; set; }
    }
}
