using SDMS_API.ViewModels.ProductFormulaDetail;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.ViewModels.ProductFormulaMaster
{
    public class ProductFormulaMasterCreateVM
    {
        [Required]
        public int ProductId { get; set; }
        public IEnumerable<ProductFormulaDetailCreateVM> ProductFormulaDetails { get; set; }
    }
}
