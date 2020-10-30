using SDMS_API.ViewModels.VoucherDetail;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.ViewModels.VoucherMaster
{
    public class VoucherMasterCreateVM
    {
        public DateTime Date { get; set; }
        public string VoucherNumberType { get; set; }
        [StringLength(2),Required]
        public string VoucherType { get; set; }
        [StringLength(50)]
        public string Narration { get; set; }
        public bool IsPosted { get; set; }
        public DateTime? ChequeDate { get; set; }
        public string ChequeNo { get; set; }
        public int AddedBy { get; set; }
        public DateTime AddedOn { get; set; }
        public IEnumerable<VoucherDetailCreateVM> VoucherDetails { get; set; }
    }
}
