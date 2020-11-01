using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.ViewModels.ManufacturingBillProductDetail
{
    public class ManufacturingBillDetailEditVM
    {
        public int ProductId { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        [StringLength(50)]
        public string BatchNo { get; set; }
    }
}
