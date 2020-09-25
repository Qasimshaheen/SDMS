using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SDMS_API.Data
{
    public class BankOpeningBalanceMaster
    {
        public int Id { get; set; }
        public int VoucherMasterId { get; set; }
        public DateTime Date { get; set; }
        public bool IsPosted { get; set; }
        [ForeignKey(nameof(VoucherMasterId))]
        public VoucherMaster TblVoucherMaster { get; set; }
    }
}
