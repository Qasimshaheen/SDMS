using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.ViewModels.Product
{
    public class ProductDetailVM
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int CategoryId { get; set; }
        public int MeasureUnitId { get; set; }
        public decimal RetailPrice { get; set; }
        public decimal ActualPrice { get; set; }
        public string Remarks { get; set; }
        public bool Status { get; set; }
        public int? CostOfGoodsSoldCOAId { get; set; }
        public int? InventoryCOAId { get; set; }
        public int? SaleCOAId { get; set; }
        public int? SaleDiscountCOAId { get; set; }
        public int? SaleReturnCOAId { get; set; }
    }
}
