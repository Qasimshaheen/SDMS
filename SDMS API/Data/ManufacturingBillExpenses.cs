using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.Data
{
    public class ManufacturingBillExpenses
    {
        public int Id { get; set; }
        public int BillId { get; set; }
        public int COAId { get; set; }
        public decimal Amount { get; set; }
        [ForeignKey(nameof(COAId))]
        public ChartofAccount TblChartofAccount { get; set; }
        [ForeignKey(nameof(BillId))]
        public ManufacturingBillMaster  TblManufacturingBillMaster { get; set; }
    }
}
