using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SDMS_API.Data
{
    public class SalesDetail
    {
        public int Id { get; set; }
        public int SalesMasterId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public string BatchNo { get; set; }
        [Required]
        public int WarehouseId { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DiscountPerc { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal NetAmount { get; set; }
        [ForeignKey(nameof(WarehouseId))]
        public Warehouse Warehouse { get; set; }
        [ForeignKey(nameof(ProductId))]
        public Product TblProduct { get; set; }
        [ForeignKey(nameof(SalesMasterId))]
        public SalesMaster TblSalesMaster { get; set; }
    }
}
