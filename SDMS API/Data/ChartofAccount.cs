using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.Data
{
    public class ChartofAccount
    {
        public int Id { get; set; }

        [StringLength(20)]
        public string Code { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Category { get; set; } 
        public bool IsDebit { get; set; }
        public int? ParentAccountId { get; set; }
        public bool IsDetailAccount { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey(nameof(ParentAccountId))]
        public ChartofAccount TblParentChartOfAccount { get; set; }
        public List<ChartofAccount> TblChildChartOfAccounts { get; set; }


        [InverseProperty("TblInventoryChartOfAccount")]
        public List<Product> TblInventoryProducts { get; set; }

        [InverseProperty("TblSaleChartOfAccount")]
        public List<Product> TblSaleProducts { get; set; }

        [InverseProperty("TblSaleReturnChartOfAccount")]
        public List<Product> TblSaleReturnProducts { get; set; }

        [InverseProperty("TblSaleDiscountChartOfAccount")]
        public List<Product> TblSaleDiscountProducts { get; set; }

        [InverseProperty("TblCostOfGoodsSoldChartOfAccount")]
        public List<Product> TblCostOfGoodsSoldProducts { get; set; }
        public List<Customer> Customers { get; set; }
        public List<Vendor> Vendors { get; set; }

    }
}

