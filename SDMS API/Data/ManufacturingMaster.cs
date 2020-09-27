using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.Data
{
    public class ManufacturingMaster
    {
        public int Id { get; set; }
        public int FormulaMasterId { get; set; }
        public int? ProductId { get; set; }
        public DateTime Date { get; set; }
        [StringLength(50)]
        public string BatchNo { get; set; }
        public int WarehouseId { get; set; }
        public decimal Quantity { get; set; }
        public bool IsPosted { get; set; }
        [ForeignKey(nameof(TblAddedByUser))]
        public int AddedBy { get; set; }
        public User TblAddedByUser { get; set; }
        public DateTime AddedOn { get; set; }
        
        [ForeignKey(nameof(TblUpdatedByUser))]
        public int? UpdatedBy { get; set; }
        public User TblUpdatedByUser { get; set; }
        public DateTime? UpdatedOn { get; set; }

        [ForeignKey(nameof(WarehouseId))]
        public Warehouse Warehouse { get; set; }
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }

        [ForeignKey(nameof(FormulaMasterId))]
        public ProductFormulaMaster TblProductFormulaMaster { get; set; }
        public List<ManufacturingDetail> ManufacturingDetails { get; set; }
    }
}
