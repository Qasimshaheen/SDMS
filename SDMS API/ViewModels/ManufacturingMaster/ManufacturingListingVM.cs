using SDMS_API.ViewModels.ManufacturingDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.ViewModels.ManufacturingMaster
{
    public class ManufacturingListingVM
    {
        public int Id { get; set; }
        public int FormulaMasterId { get; set; }
        public string ProductName { get; set; }
        public string Code { get; set; }
        public decimal Quantity { get; set; }
        public string BatchNo { get; set; }
        public string WarehouseName { get; set; }
        public string Status { get; set; }
        public IEnumerable<ManufacturingDetailListingVM> ManufacturingDetails { get; set; }
    }
}
