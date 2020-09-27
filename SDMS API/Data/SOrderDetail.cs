using System.ComponentModel.DataAnnotations.Schema;

namespace SDMS_API.Data
{
    public class SOrderDetail
    {
        public int Id { get; set; }
        public int SOrderId { get; set; }
        public int ProductId { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DiscountPerc { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal NetAmount { get; set; }
        [ForeignKey(nameof(ProductId))]
        public Product TblProduct { get; set; }
        [ForeignKey(nameof(SOrderId))]
        public SOrderMaster TblSOrderMaster { get; set; }
    }
}
