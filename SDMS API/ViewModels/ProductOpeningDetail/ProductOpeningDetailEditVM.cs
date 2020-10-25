using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.ViewModels.ProductOpeningDetail
{
    public class ProductOpeningDetailEditVM
    {
        public int ProductId { get; set; }
        [StringLength(50), Required]
        public string BatchNo { get; set; }
        public int WarehouseId { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Amount { get; set; }
    }
}
