using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.ViewModels.ManufacturingBillProductDetail
{
    public class ManufacturingBillDetailListingVM
    {
        public string ProductName { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public string BatchNo { get; set; }
    }
}
