using SDMS_API.ViewModels.SOrderDetail;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.ViewModels.SOrderMaster
{
    public class SOrderMasterEditVM
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DiscountPerc { get; set; }
        public decimal DiscountAmount { get; set; }
        public bool IsPosted { get; set; }
        [StringLength(100)]
        public string Remarks { get; set; }
        public int UpdatedBy { get; set; }
        public IEnumerable<SOrderDetailEditVM> SOrderDetails { get; set; }
    }
}
