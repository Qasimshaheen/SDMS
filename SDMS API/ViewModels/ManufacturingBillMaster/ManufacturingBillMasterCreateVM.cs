using SDMS_API.ViewModels.ManufacturingBillExpense;
using SDMS_API.ViewModels.ManufacturingBillProductDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.ViewModels.ManufacturingBillMaster
{
    public class ManufacturingBillMasterCreateVM
    {
        public int ManufacturingId { get; set; }
        public DateTime Date { get; set; }
        public decimal RawMaterialCost { get; set; }
        public decimal ExpenseCost { get; set; }
        public decimal TotalCost { get; set; }
        public bool IsPosted { get; set; }
        public int AddedBy { get; set; }
        public IEnumerable<ManufacturingBillDetailCreateVM> ManufacturingBillDetails { get; set; }
        public IEnumerable<ManufacturingBillExpenseCreateVM> ManufacturingBillExpenses { get; set; }
    }
}
