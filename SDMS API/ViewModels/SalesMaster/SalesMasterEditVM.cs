﻿using SDMS_API.ViewModels.SalesDetail;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.ViewModels.SalesMaster
{
    public class SalesMasterEditVM
    {
        public int Id { get; set; }
        public int SOrderId { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public int CustomerId { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DiscountPerc { get; set; }
        public decimal DiscountAmount { get; set; }
        [StringLength(100)]
        public string Remarks { get; set; }
        public bool IsPosted { get; set; }
        public int UpdatedBy { get; set; }
        public IEnumerable<SalesDetailEditVM> SalesDetails { get; set; }
    }
}
