using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.ViewModels.ProductLedger
{
    public class ProductLedgerBalanceByProductIdVM
    {
        public int ProductId { get; set; }
        public decimal Balance { get; set; }
        public string BatchNo { get; set; }
        public int WarehouseId { get; set; }
        public string WarehouseName { get; set; }
    }
}
