using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.Data
{
    public class CustomerOpeningBalanceDetail
    {
        public int Id { get; set; }
        public int CustomerOBMId { get; set; }
        public int CustomerId { get; set; }
        public decimal OpeningBalance { get; set; }
        public decimal OpeningReceipt { get; set; }
        public decimal OpeningAdvance { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public Customer TblCustomer { get; set; }
        [ForeignKey(nameof(CustomerOBMId))]
        public CustomerOpeningBalanceMaster TblCustomerOpeningBalanceMaster { get; set; }
    }
}
