using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.Data
{
    public class VoucherMaster
    {
        public int Id { get; set; }
        public string VoucherNumber { get; set; }
        public DateTime Date { get; set; }
        [StringLength(2)]
        public string VoucherType { get; set; }
        [StringLength(50)]
        public string Narration { get; set; }
        public decimal? TotalDebit { get; set; }
        public decimal? TotalCredit { get; set; }
        public bool IsPosted { get; set; }
        public DateTime? ChequeDate { get; set; }
        public string ChequeNo { get; set; }
        public int BankId { get; set; }
        [ForeignKey(nameof(TblAddedByUser))]
        public int AddedBy { get; set; }
        public User TblAddedByUser { get; set; }
        public DateTime AddedOn { get; set; }
        [ForeignKey(nameof(TblUpdatedByUser))]
        public int? UpdatedBy { get; set; }
        public User TblUpdatedByUser { get; set; }
        public DateTime? UpdatedOn { get; set; }

        [ForeignKey(nameof(BankId))]
        public Bank TblBank { get; set; }
        public List<VoucherDetail> VoucherDetails { get; set; }
        public List<CustomerOpeningBalanceMaster> CustomerOpeningBalanceMasters { get; set; }
        public List<VendorOpeningBalanceMaster> VendorOpeningBalanceMasters { get; set; }
        public List<BankOpeningBalanceMaster> bankOpeningBalanceMastes { get; set; }
        public List<PurchaseMaster> PurchaseMasters { get; set; }
        public List<SalesMaster> SalesMasters { get; set; }
    }
}
