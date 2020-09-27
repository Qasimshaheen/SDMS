using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.Data
{
    public class Product
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int MeasureUnitID { get; set; }


        [StringLength(20)]
        public string Code { get; set; }

        public decimal RetailPrice { get; set; }
        public decimal ActualPrice { get; set; }

        [StringLength(100)]
        public string Remarks { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }


        [ForeignKey(nameof(TblInventoryChartOfAccount))]

        public int? InventoryCOAId { get; set; }
        public ChartofAccount TblInventoryChartOfAccount { get; set; }




        [ForeignKey(nameof(TblSaleChartOfAccount))]

        public int? SaleCOAId { get; set; }
        public ChartofAccount TblSaleChartOfAccount { get; set; }



        [ForeignKey(nameof(TblSaleReturnChartOfAccount))]

        public int? SaleReturnCOAId { get; set; }
        public ChartofAccount TblSaleReturnChartOfAccount { get; set; }



        [ForeignKey(nameof(TblSaleDiscountChartOfAccount))]

        public int? SaleDiscountCOAId { get; set; }
        public ChartofAccount TblSaleDiscountChartOfAccount { get; set; }



        [ForeignKey(nameof(TblCostOfGoodsSoldChartOfAccount))]

        public int? CostOfGoodsSoldCOAId { get; set; }
        public ChartofAccount TblCostOfGoodsSoldChartOfAccount { get; set; }

        [ForeignKey(nameof(MeasureUnitID))]
        public MeasureUnit TblMeasureUnit { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public ProductCategory TblProductCategory { get; set; }
        public List<ProductOpeningBalanceDetail> ProductOpeningBalanceDetails { get; set; }
        public List<ProductFormulaMaster> ProductFormulaMasters { get; set; }
        public List<ProductFormulaDetail> ProductFormulaDetails { get; set; }
        public List<ManufacturingDetail> ManufacturingDetails { get; set; }
        public List<ProductLedger> ProductLedgers { get; set; }
        public List<ManufacturingMaster> ManufacturingMasters { get; set; }
        public List<PurchaseDetail> PurchaseDetails { get; set; }
        
    }
}
