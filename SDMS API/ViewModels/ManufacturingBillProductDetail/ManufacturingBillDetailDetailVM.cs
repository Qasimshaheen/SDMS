using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.ViewModels.ManufacturingBillProductDetail
{
    public class ManufacturingBillDetailDetailVM
    {
        public string ProductName { get; set; }
        public decimal Quantity { get; set; }
        public decimal Amount { get; set; }
        public string BatchNo { get; set; }
    }
}
