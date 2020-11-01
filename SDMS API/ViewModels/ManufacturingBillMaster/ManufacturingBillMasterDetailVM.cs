using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.ViewModels.ManufacturingBillMaster
{
    public class ManufacturingBillMasterDetailVM
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string ManufacturingNumber { get; set; }
        public string VoucherNumber { get; set; }
        public DateTime Date { get; set; }
        public decimal RawMaterialCost { get; set; }
        public decimal ExpenseCost { get; set; }
        public decimal TotalCost { get; set; }
        public string PostStatus { get; set; }
        public string CreatedBy { get; set; }
    }
}
