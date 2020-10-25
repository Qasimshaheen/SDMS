using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.ViewModels.ProductOpeningDetail
{
    public class ProductOpeningDetailDetailVM
    {
        public string ProductName { get; set; }
        public string BatchNo { get; set; }
        public string WarehouseName { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Amount { get; set; }
    }
}
