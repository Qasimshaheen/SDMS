using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.Data
{
    public class Warehouse
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(80)]
        public string Address { get; set; }
        public List<Company> Companies { get; set; }
        public List<ProductLedger> ProductLedgers { get; set; }
        public List<ManufacturingMaster> ManufacturingMasters { get; set; }
        public List<ManufacturingRawDetail> ManufacturingRawDetails { get; set; }
        public List<SalesDetail> SalesDetails { get; set; }
        public List<ProductOpeningBalanceDetail> ProductOpeningBalanceDetails { get; set; }
    }
}
