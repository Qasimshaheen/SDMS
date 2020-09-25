using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SDMS_API.Data
{
    public class BankAccoountDetail
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string BranchName { get; set; }
        public int COAId { get; set; }
        public int BankId { get; set; }
        public int BankAccountTypeId { get; set; }
        [StringLength(50)]
        public string AccountTitle { get; set; }
        [StringLength(80)]
        public string AccountNumber { get; set; }
        [ForeignKey(nameof(BankAccountTypeId))]
        public BankAccountType TblBankAccountType { get; set; }
        [ForeignKey(nameof(BankId))]
        public Bank TblBank { get; set; }
        [ForeignKey(nameof(COAId))]
        public ChartofAccount TblChartofAccount { get; set; }

    }
}
