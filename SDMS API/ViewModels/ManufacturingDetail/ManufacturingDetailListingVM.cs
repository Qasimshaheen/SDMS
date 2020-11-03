using SDMS_API.ViewModels.ManufacturingRawDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.ViewModels.ManufacturingDetail
{
    public class ManufacturingDetailListingVM
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal RequiredQuantity { get; set; }
        public IEnumerable<ManufacturingRawDetailListingVM> ManufacturingRawDetails { get; set; }
    }
}
