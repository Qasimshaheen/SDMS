using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace SDMS_API.Data
{
    public class Vendor
    {
        public int Id { get; set; }
        public int COAId { get; set; }
        public int CityId { get; set; }
        [StringLength(20)]
        public string Code { get; set; }
        [StringLength(20)]
        public string Name { get; set; }
        [StringLength(13)]
        public string ContactNumber { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(80)]
        public string Address { get; set; }
        public bool IsActive { get; set; }
        [ForeignKey(nameof(COAId))]
        public ChartofAccount TblChartofAccount { get; set; }
        [ForeignKey(nameof(CityId))]
        public City TblCity { get; set; }
        public List<VoucherDetail> VoucherDetails { get; set; }
        public VendorOpeningBalanceDetail TblVendorOpeningBalanceDetail { get; set; }
        public List<PurchaseMaster> PurchaseMasters { get; set; }
    }
}