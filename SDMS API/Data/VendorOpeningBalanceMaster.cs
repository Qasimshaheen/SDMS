using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.Data
{
    public class VendorOpeningBalanceMaster
    {
        public int Id { get; set; }
        [StringLength(20)]
        public int VoucherMasterId { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey(nameof(VoucherMasterId))]
        public VoucherMaster TblVoucherMaster { get; set; }
        public bool IsPosted { get; set; }
        public List<VendorOpeningBalanceDetail> VendorOpeningBalanceDetails { get; set; }
    }
}
