using SDMS_API.ViewModels.BankOpeningDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.ViewModels.BankOpeningMaster
{
    public class BankOpeningMasterEditVM
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<BankOpeningDetailEditVM> BankOpeningDetails { get; set; }
    }
}
    