using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.ViewModels.Company
{
    public class CompanyCreateVM
    {
        public int WarehouseId { get; set; }
        [StringLength(50),Required]
        public string Name { get; set; }
        [StringLength(80)]
        public string Address { get; set; }
        [StringLength(13)]
        public string ContactNumber { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(10)]
        public string NTN { get; set; }
    }
}
