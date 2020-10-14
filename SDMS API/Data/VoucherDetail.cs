using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.Data
{
    public class VoucherDetail
    {
        public int Id { get; set; }
        public int VoucherMasterId { get; set; }
        public int? CustomerId { get; set; }
        public int? VendorId { get; set; }
        [Required]
        public int COAId { get; set; }
        [Required] 
        public bool IsDebit { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [StringLength(100)]
        public string Remarks { get; set; }
        [ForeignKey(nameof(COAId))]
        public ChartofAccount ChartofAccount { get; set; }
        [ForeignKey(nameof(VendorId))]
        public Vendor TblVendor { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public Customer TblCustomer { get; set; }

        [ForeignKey(nameof(VoucherMasterId))]
        public VoucherMaster TblVoucherMaster { get; set; }
    }
}
