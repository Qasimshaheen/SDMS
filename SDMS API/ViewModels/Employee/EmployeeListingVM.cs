using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.ViewModels.Employee
{
    public class EmployeeListingVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactNo { get; set; }
        public string DepartmentName { get; set; }
        public string ShiftName { get; set; }
        public string Status { get; set; }
    }
}
