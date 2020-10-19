using SDMS_API.ViewModels.ManufacturingRawDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.ViewModels.ManufacturingDetail
{
    public class ManufacturingDetailEditVM
    {
        public int ProductId { get; set; }
        public IEnumerable<ManufacturingRawDetailEditVM> ManufacturingRawDetails { get; set; }
    }
}
