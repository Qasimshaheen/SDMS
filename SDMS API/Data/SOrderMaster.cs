﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.Data
{
    public class SOrderMaster
    {
        public int Id { get; set; }
        [StringLength(20)]
        public string Code { get; set; }
        public int CustomerId { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DiscountPerc { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal NetAmount { get; set; }
        public bool IsPosted { get; set; }
        [StringLength(100)]
        public string Remarks { get; set; }
        [ForeignKey(nameof(TblAddedByUser))]
        public int AddedBy { get; set; }
        public User TblAddedByUser { get; set; }
        public DateTime AddedOn { get; set; }

        [ForeignKey(nameof(TblUpdatedByUser))]
        public int? UpdatedBy { get; set; }
        public User TblUpdatedByUser { get; set; }
        public DateTime? UpdatedOn { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public Customer TblCustomer { get; set; }
        public List<SOrderDetail> SOrderDetails { get; set; }
    }
}
