using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.ViewModels.Vendor
{
    public class VendorListingVM
    {
        public int Id { get; set; }
        public string AccountName { get; set; }
        public string CityName { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
    }
}
