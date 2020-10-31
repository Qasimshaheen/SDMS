using SDMS_API.ViewModels.BankOpeningDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.ViewModels.BankOpeningMaster
{
    public class BankOpeningMasterCreateVM
    {
        public DateTime Date { get; set; }
        public bool IsPosted { get; set; }
        public IEnumerable<BankOpeningDetailCreateVM> BankOpeningDetails { get; set; }
    }
}
