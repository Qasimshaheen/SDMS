using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.ViewModels.ManufacturingMaster
{
    public class RawMaterialPriceVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Quantity { get; set; }
        public string BatchNo { get; set; }
        public decimal AvgRate { get; set; }

    }
}
