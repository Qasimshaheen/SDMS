using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.ViewModels.SalesDetail
{
    public class SalesDetailCreateVM
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int WarehouseId { get; set; }
        [Required]
        public string BatchNo { get; set; }
        [Required]
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DiscountPerc { get; set; }
        public decimal DiscountAmount { get; set; }
    }
}
