﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.ViewModels.Shift
{
    public class ShiftCreateVM
    {
        [StringLength(50),Required]
        public string Name { get; set; }
    }
}
