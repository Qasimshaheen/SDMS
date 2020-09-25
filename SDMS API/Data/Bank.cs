using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace SDMS_API.Data
{
    public class Bank
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public List<BankAccoountDetail> BankAccoountDetails { get; set; }
    }
}
