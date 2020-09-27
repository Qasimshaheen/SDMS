using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SDMS_API.Data
{
    public class ManufacturingDetail
    {
        public int Id { get; set; }
        public int ManufacturingMasterId { get; set; }
        public int? ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public Product TblProduct { get; set; }
        [ForeignKey(nameof(ManufacturingMasterId))]
        public ManufacturingMaster TblManufacturingMaster { get; set; }
        public List<ManufacturingRawDetail> ManufacturingRawDetails { get; set; }
    }
}
