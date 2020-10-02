using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.ViewModels.Warehouse
{
    public class WarehouseEditVM
    {
        public int Id { get; set; }
        [StringLength(50),Required]
        public string Name { get; set; }
        [StringLength(100)]
        public string Address { get; set; }
    }
}
