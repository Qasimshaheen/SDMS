using SDMS_API.ViewModels.ManufacturingDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.ViewModels.ManufacturingMaster
{
    public class ManufacturingMasterDetailVM
    {
        public int FormulaMasterId { get; set; }
        public string Code { get; set; }
        public string ProductName { get; set; }
        public DateTime Date { get; set; }
        public string BatchNo { get; set; }
        public string WarehouseName { get; set; }
        public decimal Quantity { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public IEnumerable<ManufacturingDetailDetailVM> ManufacturingDetails { get; set; }
    }
}
