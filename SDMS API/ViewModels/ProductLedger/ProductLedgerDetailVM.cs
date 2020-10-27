using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.ViewModels.ProductLedger
{
    public class ProductLedgerDetailVM
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public DateTime Date { get; set; }
        public string TransNo { get; set; }
        public string InOutStatus { get; set; }
        public decimal Quantity { get; set; }
        public string SerialNo { get; set; }
        public string WarehouseName { get; set; }
        public string BatchNo { get; set; }
        public string Remarks { get; set; }
    }
}
