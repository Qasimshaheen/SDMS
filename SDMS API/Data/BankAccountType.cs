using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SDMS_API.Data
{
    public class BankAccountType
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
        public List<BankAccoountDetail> BankAccoountDetails { get; set; }
    }
}
