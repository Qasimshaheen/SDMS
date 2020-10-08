using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.ViewModels.Employee
{
    public class EmployeeDetailVM
    {
        public int Id { get; set; }
        public DateTime HireDate { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public string Gender { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string NIC { get; set; }
        public string Address { get; set; }
        public string DepartmentName { get; set; }
        public string ShiftName { get; set; }
        public string Status { get; set; }
    }
}
