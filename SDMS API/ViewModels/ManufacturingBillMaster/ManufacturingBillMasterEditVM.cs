using SDMS_API.ViewModels.ManufacturingBillExpense;
using SDMS_API.ViewModels.ManufacturingBillProductDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.ViewModels.ManufacturingBillMaster
{
    public class ManufacturingBillMasterEditVM
    {
        public int Id { get; set; }
        public int ManufacturingId { get; set; }
        public DateTime Date { get; set; }
        public decimal RawMaterialCost { get; set; }
        public decimal ExpenseCost { get; set; }
        public decimal TotalCost { get; set; }
        public int UpdatedBy { get; set; }
        public IEnumerable<ManufacturingBillDetailEditVM> ManufacturingBillDetails { get; set; }
        public IEnumerable<ManufacturingBillExpenseEditVM> ManufacturingBillExpenses { get; set; }
    }
}
