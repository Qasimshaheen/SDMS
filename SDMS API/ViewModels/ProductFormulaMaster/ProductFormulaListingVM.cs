using SDMS_API.ViewModels.ProductFormulaDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.ViewModels.ProductFormulaMaster
{
    public class ProductFormulaListingVM
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public IEnumerable<ProductFormulaDetailListingVM> ProductFormulaDetails { get; set; }
    }
}
