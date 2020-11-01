using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.Data
{
    public class ManufacturingBillMaster
    {
        public int Id { get; set; }
        public int? ManufacturingId { get; set; }
        public int? VoucherMasterId { get; set; }
        public DateTime Date { get; set; }
        [StringLength(20)]
        public string Code { get; set; }
        public decimal RawMaterialCost { get; set; }
        public decimal ExpenseCost { get; set; }
        public decimal TotalCost { get; set; }
        public bool IsPosted { get; set; }
        [ForeignKey(nameof(TblAddedByUser))]
        public int AddedBy { get; set; }
        public User TblAddedByUser { get; set; }
        public DateTime AddedOn { get; set; }

        [ForeignKey(nameof(TblUpdatedByUser))]
        public int? UpdatedBy { get; set; }
        public User TblUpdatedByUser { get; set; }
        public DateTime? UpdatedOn { get; set; }
        [ForeignKey(nameof(VoucherMasterId))]
        public VoucherMaster TblVoucherMaster { get; set; }
        [ForeignKey(nameof(ManufacturingId))]
        public ManufacturingMaster TblManufacturingMaster { get; set; }
        public List<ManufacturingBillProductDetail> ManufacturingBillProductDetails { get; set; }
    }
}
