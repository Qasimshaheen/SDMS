using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.Data
{
    public class ManufacturingBillProductDetail
    {
        public int Id { get; set; }
        public int BillId { get; set; }
        public int ProductId { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        [StringLength(50)]
        public string BatchNo { get; set; }
        [ForeignKey(nameof(ProductId))]
        public Product TblProduct { get; set; }
        [ForeignKey(nameof(BillId))]
        public ManufacturingBillMaster TblManufacturingBillMaster { get; set; }
    }
}
