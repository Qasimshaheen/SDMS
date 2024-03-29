﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.Data
{
    public class City
    {
        public int Id { get; set; }
        [StringLength(50),Required]
        public string Name { get; set; }
        public List<Customer> Customers { get; set; }
        public List<Vendor> Vendors { get; set; }
    }
}
