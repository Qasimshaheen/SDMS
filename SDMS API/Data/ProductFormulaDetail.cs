using System.ComponentModel.DataAnnotations.Schema;

namespace SDMS_API.Data
{
    public class ProductFormulaDetail
    {
        public int Id { get; set; }
        public int FormulaMasterId { get; set; }
        public int? ProductId { get; set; }
        public decimal Quantity { get; set; }
        [ForeignKey(nameof(ProductId))]
        public Product TblProduct { get; set; }
        [ForeignKey(nameof(FormulaMasterId))]
        public ProductFormulaMaster TblProductFormulaMaster { get; set; }
    }
}
