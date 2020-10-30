using SDMS_API.ViewModels.SalesDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.ViewModels.SalesMaster
{
    public class SalesMasterDetailVM
    {
        public int Id { get; set; }
        public string SOrderNo { get; set; }
        public string SINo { get; set; }
        public DateTime Date { get; set; }
        public string VoucherNumber { get; set; }
        public string CustomerName { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DiscountPerc { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal NetAmount { get; set; }
        public string Remarks { get; set; }
        public string PostStatus { get; set; }
        public IEnumerable<SalesDetailDetailVM> SalesDetails { get; set; }
    }
}
