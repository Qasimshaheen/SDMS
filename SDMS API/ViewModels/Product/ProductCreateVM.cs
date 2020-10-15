using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.ViewModels.Product
{
    public class ProductCreateVM
    {
        public int MeasureUnitId { get; set; }
        public int ProductCategoryId { get; set; }
        [StringLength(50),Required]
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public decimal RetailPrice { get; set; }
        public decimal ActualPrice { get; set; }
        [StringLength(100)]
        public string Remarks { get; set; }
        public bool IsActive { get; set; }
        public int? CostOfGoodsSoldCOAId { get; set; }
        public int? InventoryCOAId { get; set; }
        public int? SaleCOAId { get; set; }
        public int? SaleDiscountCOAId { get; set; }
        public int? SaleReturnCOAId { get; set; }
    }
}
