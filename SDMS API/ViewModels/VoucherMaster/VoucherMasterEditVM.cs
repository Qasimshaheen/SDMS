using SDMS_API.ViewModels.VoucherDetail;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.ViewModels.VoucherMaster
{
    public class VoucherMasterEditVM
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        [StringLength(50)]
        public string Narration { get; set; }
        public DateTime? ChequeDate { get; set; }
        public string ChequeNo { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public IEnumerable<VoucherDetailEditVM> VoucherDetails { get; set; }
    }
}
