using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.ViewModels.BankAccountDetail
{
    public class BankAccountDetailCreateVM
    {
        [StringLength(50)]
        public string BranchName { get; set; }
        public int COAId { get; set; }
        public int BankId { get; set; }
        public int BankAccountTypeId { get; set; }
        [StringLength(50)]
        public string AccountTitle { get; set; }
        [StringLength(80)]
        public string AccountNumber { get; set; }
    }
}
