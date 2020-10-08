using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.ViewModels.City
{
    public class CityCreateVM
    {
        [StringLength(50), Required]
        public string Name { get; set; }
    }
}
