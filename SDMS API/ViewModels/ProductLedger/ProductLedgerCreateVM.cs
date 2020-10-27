using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.ViewModels.ProductLedger
{
    public class ProductLedgerCreateVM
    {
        public int ProductId { get; set; }
        public DateTime Date { get; set; }
        [StringLength(20)]
        public string TransNo { get; set; }
        public bool IsOut { get; set; }
        public decimal Quantity { get; set; }
        [StringLength(50)]
        public string SerialNo { get; set; }
        public int WarehouseId { get; set; }
        [StringLength(50)]
        public string BatchNo { get; set; }
        [StringLength(100)]
        public string Remarks { get; set; }
        public int AddedBy { get; set; }
    }
}
