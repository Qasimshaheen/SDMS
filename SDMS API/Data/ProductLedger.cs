using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.Data
{
    public class ProductLedger
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public DateTime Date { get; set; }
        [StringLength(20)]
        public string TransNo { get; set; }
        public bool IsInOut { get; set; }
        public decimal Quantity { get; set; }
        [StringLength(50)]
        public string BatchNo { get; set; }
        public int WarehouseId { get; set; }
        [StringLength(50)]
        public string Remarks { get; set; }
        [ForeignKey(nameof(WarehouseId))]
        public Warehouse TblWarehouse { get; set; }
        [ForeignKey(nameof(ProductId))]
        public Product TblProduct { get; set; }
    }
}
