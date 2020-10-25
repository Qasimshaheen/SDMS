using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.Data
{
    public class ProductOpeningBalanceMaster
    {
        public int Id { get; set; }
        public int? VoucherMasterId{ get; set; }
        public DateTime Date { get; set; }
        public bool IsPosted { get; set; }
        [ForeignKey(nameof(VoucherMasterId))]
        public VoucherMaster TblVoucherMaster { get; set; }
        public List<ProductOpeningBalanceDetail> ProductOpeningBalanceDetails { get; set; }
    }
}
