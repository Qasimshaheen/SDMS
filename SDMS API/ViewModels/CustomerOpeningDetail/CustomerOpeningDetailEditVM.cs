using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.ViewModels.CustomerOpeningDetail
{
    public class CustomerOpeningDetailEditVM
    {
        public int CustomerId { get; set; }
        public decimal OpeningBalance { get; set; }
        public decimal OpeningReceipt { get; set; }
        public decimal OpeningAdvance { get; set; }
    }
}
