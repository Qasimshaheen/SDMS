using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.ViewModels.BankAccountDetail
{
    public class BankAccountDetailListingVM
    {
        public int Id { get; set; }
        public string BankName { get; set; }
        public string BranchName { get; set; }
        public string BankAccountTypeName { get; set; }
        public string AccountTitle { get; set; }
        public string AccountNumber { get; set; }
    }
}
