using SDMS_API.ViewModels.ProductOpeningDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.ViewModels.ProductOpeningMaster
{
    public class ProductOpeningMasterEditVM
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<ProductOpeningDetailEditVM> ProductOpeningDetails { get; set; }
    }
}
