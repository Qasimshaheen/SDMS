using SDMS_API.ViewModels.ManufacturingRawDetail;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.ViewModels.ManufacturingDetail
{
    public class ManufacturingDetailCreateVM
    {
        [Required]
        public int ProductId { get; set; }
        public IEnumerable<ManufacturingRawDetailCreateVM> ManufacturingRawDetails { get; set; }
    }
}
