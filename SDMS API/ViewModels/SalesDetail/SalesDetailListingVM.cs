using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.ViewModels.SalesDetail
{
    public class SalesDetailListingVM
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string WarehouseName { get; set; }
        public string BatchNo { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal NetAmount { get; set; }
    }
}
