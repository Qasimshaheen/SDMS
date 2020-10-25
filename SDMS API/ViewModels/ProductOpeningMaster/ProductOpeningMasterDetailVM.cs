using SDMS_API.ViewModels.ProductOpeningDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.ViewModels.ProductOpeningMaster
{
    public class ProductOpeningMasterDetailVM
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string VoucherNumber { get; set; }
        public string PostStatus { get; set; }
        public IEnumerable<ProductOpeningDetailDetailVM> ProductOpeningDetails { get; set; }
    }
}
