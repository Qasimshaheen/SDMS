using SDMS_API.ViewModels.SOrderDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.ViewModels.SOrderMaster
{
    public class SOrderListingsVM
    {
        public string CustomerName { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal NetAmount { get; set; }
        public string PostStatus { get; set; }
        public string Remarks { get; set; }
        public IEnumerable<SOrderDetailListingVM> SOrderDetails { get; set; }
    }
}
