using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SDMS_API.Data
{
    public class ManufacturingRawDetail
    {
        public int Id { get; set; }
        public int ManufacturingDetailMasterId { get; set; }
        public int? WarehouseId { get; set; }
        [StringLength(50)]
        public string BatchNo { get; set; }
        public decimal Quantity { get; set; }
        [ForeignKey(nameof(ManufacturingDetailMasterId))]
        public ManufacturingDetail TblManufacturingDetail { get; set; }
        [ForeignKey(nameof(WarehouseId))]
        public Warehouse TblWarehouse { get; set; }
    }
}
