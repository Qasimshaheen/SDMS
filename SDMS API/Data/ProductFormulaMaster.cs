using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.Data
{
    public class ProductFormulaMaster
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public Product TblProduct { get; set; }
        public List<ProductFormulaDetail> ProductFormulaDetails { get; set; }
        public List<ManufacturingMaster> ManufacturingMasters { get; set; }
    }
}
