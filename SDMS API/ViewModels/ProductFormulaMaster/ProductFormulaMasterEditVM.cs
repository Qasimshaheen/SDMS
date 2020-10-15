using SDMS_API.ViewModels.ProductFormulaDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.ViewModels.ProductFormulaMaster
{
    public class ProductFormulaMasterEditVM
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public IEnumerable<ProductFormulaDetailEditVM> ProductFormulaDetails { get; set; }
    }
}
