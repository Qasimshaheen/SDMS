using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.ViewModels.Customer
{
    public class CustomerDetailVM
    {
        public int Id { get; set; }
        public string AccountName { get; set; }
        public string CityName { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
    }
}
