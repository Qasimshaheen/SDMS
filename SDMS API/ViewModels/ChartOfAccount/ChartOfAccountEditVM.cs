using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.ViewModels.ChartOfAccount
{
    public class ChartOfAccountEditVM
    {
        public int Id { get; set; }
        [StringLength(20)]
        public string AccountCode { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Category { get; set; }
        public bool IsDebit { get; set; }
        public int? ParentAccountId { get; set; }
        public bool IsDetailAccount { get; set; }
        public bool IsActive { get; set; }
    }
}
