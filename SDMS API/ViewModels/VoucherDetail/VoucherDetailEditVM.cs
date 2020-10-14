using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.ViewModels.VoucherDetail
{
    public class VoucherDetailEditVM
    {
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
    }
}
