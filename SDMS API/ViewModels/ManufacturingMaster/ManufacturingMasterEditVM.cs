using SDMS_API.ViewModels.ManufacturingDetail;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.ViewModels.ManufacturingMaster
{
    public class ManufacturingMasterEditVM
    {
        public int Id { get; set; }
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
        public int UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public IEnumerable<ManufacturingDetailEditVM> ManufacturingDetails { get; set; }
    }
}
