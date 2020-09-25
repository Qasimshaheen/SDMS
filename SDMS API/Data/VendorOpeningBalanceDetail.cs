using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.Data
{
    public class VendorOpeningBalanceDetail
    {
        public int Id { get; set; }
        public int VendorOBMasterId { get; set; }
        public int VendorId { get; set; }
        public decimal OpeningBalance { get; set; }
        public decimal OpeningReceipt { get; set; }
        public decimal OpeningAdvance { get; set; }
        [ForeignKey(nameof(VendorId))]
        public Vendor TblVendor { get; set; }
        [ForeignKey(nameof(VendorOBMasterId))]
        public VendorOpeningBalanceMaster TblVendorOpeningBalanceMaster { get; set; }
    }
}
