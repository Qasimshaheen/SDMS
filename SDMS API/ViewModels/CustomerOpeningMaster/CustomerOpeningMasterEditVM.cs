using SDMS_API.ViewModels.CustomerOpeningDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.ViewModels.CustomerOpeningMaster
{
    public class CustomerOpeningMasterEditVM
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<CustomerOpeningDetailEditVM> CustomerOpeningDetails { get; set; }
    }
}
