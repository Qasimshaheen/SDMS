using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.ViewModels.ProductCategory
{
    public class ProductCategoryEditVM
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
    }
}
