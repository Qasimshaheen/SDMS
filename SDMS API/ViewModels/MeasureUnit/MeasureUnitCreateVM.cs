using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.ViewModels.MesureUnit
{
    public class MeasureUnitCreateVM
    {
        [StringLength(50)]
        public string Name { get; set; }
    }
}
