using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SDMS_API.Data
{
    public class ProductOpeningBalanceDetail
    {
        public int Id { get; set; }
        public int ProductOBMId { get; set; }
        public int ProductId { get; set; }
        [StringLength(50)]
        public string BatchNo { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Amount { get; set; }
        public int WarehouseId { get; set; }
        [ForeignKey(nameof(WarehouseId))]
        public Warehouse TblWarehouse { get; set; }
        [ForeignKey(nameof(ProductId))]
        public Product TblProduct { get; set; }
        [ForeignKey(nameof(ProductOBMId))]
        public ProductOpeningBalanceMaster TblProductOpeningBalanceMaster { get; set; }
    }
}
