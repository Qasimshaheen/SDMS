using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.ViewModels.BankOpeningDetail
{
    public class BankOpeningDetailListingVM
    {
        public int Id { get; set; }
        public string BankAccountName { get; set; }
        public decimal OpeningBalance { get; set; }
    }
}
