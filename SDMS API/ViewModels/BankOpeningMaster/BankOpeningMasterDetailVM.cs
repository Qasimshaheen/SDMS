using SDMS_API.ViewModels.BankOpeningDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace SDMS_API.ViewModels.BankOpeningMaster
{
    public class BankOpeningMasterDetailVM
    {
        public int Id { get; set; }
        public string VoucherNumber { get; set; }
        public DateTime Date { get; set; }
        public string PostStatus { get; set; }
        public IEnumerable<BankOpeningDetailDetailVM> BankOpeningDetails { get; set; }
    }
}
