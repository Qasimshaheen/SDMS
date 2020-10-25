using SDMS_API.ViewModels.ProductOpeningDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.ViewModels.ProductOpeningMaster
{
    public class ProductOpeningMasterCreateVM
    {
        public DateTime Date { get; set; }
        public bool IsPosted { get; set; }
        public IEnumerable<ProductOpeningDetailCreateVM> ProductOpeningDetails { get; set; }
    }
}
