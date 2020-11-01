﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.ViewModels.ManufacturingBillMaster
{
    public class ManufacturingBillMasterListingVM
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string ManufacturingNumber { get; set; }
        public string VoucherNumber { get; set; }
        public DateTime Date { get; set; }
        public string PostStatus { get; set; }
        public string CreatedBy { get; set; }
    }
}
