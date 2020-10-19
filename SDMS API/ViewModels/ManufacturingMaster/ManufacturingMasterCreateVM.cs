using SDMS_API.ViewModels.ManufacturingDetail;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.ViewModels.ManufacturingMaster
{
    public class ManufacturingMasterCreateVM
    {
        [Required]
        public int FormulaMasterId { get; set; }
        [Required]
        public int? ProductId { get; set; }
        public DateTime Date { get; set; }
        [StringLength(50), Required]
        public string BatchNo { get; set; }
        [Required]
        public int WarehouseId { get; set; }
        [Required]
        public decimal Quantity { get; set; }
        [Required]
        public bool IsPosted { get; set; }
        [Required]
        public int AddedBy { get; set; }
        [Required]
        public DateTime AddedOn { get; set; }
        public IEnumerable<ManufacturingDetailCreateVM> ManufacturingDetails { get; set; }
    }
}
