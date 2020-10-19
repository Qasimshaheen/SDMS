using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.ViewModels.ManufacturingRawDetail
{
    public class ManufacturingRawDetailCreateVM
    {
        [Required]
        public int WarehouseId { get; set; }
        [StringLength(50), Required]
        public string BatchNo { get; set; }
        public decimal Quantity { get; set; }
    }
}
