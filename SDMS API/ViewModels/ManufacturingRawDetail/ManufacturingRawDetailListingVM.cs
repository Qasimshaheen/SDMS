using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.ViewModels.ManufacturingRawDetail
{
    public class ManufacturingRawDetailListingVM
    {
        public int Id { get; set; }
        public string WarehouseName { get; set; }
        public string BatchNo { get; set; }
        public decimal Quantity { get; set; }
    }
}
