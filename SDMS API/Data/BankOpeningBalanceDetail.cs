using System.ComponentModel.DataAnnotations.Schema;

namespace SDMS_API.Data
{
    public class BankOpeningBalanceDetail
    {
        public int Id { get; set; }
        public int BankOBMId { get; set; }
        public int BankAccountDetailId { get; set; }
        public decimal OpeningBalance { get; set; }
        [ForeignKey(nameof(BankAccountDetailId))]
        public BankAccoountDetail TblBankAccoountDetail { get; set; }
        [ForeignKey(nameof(BankOBMId))]
        public BankOpeningBalanceMaster  TblBankOpeningBalanceMaster { get; set; }
    }
}
