using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.ViewModels.Employee
{
    public class EmployeeCreateVM
    {
        public int? DepartmentId { get; set; }
        public int? ShiftId { get; set; }
        [StringLength(50),Required]
        public string Name { get; set; }
        [StringLength(50), Required]
        public string FatherName { get; set; }
        public DateTime HireDate { get; set; }
        [StringLength(10)]
        public string Gender { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(13)]
        public string ContactNo { get; set; }
        [StringLength(15)]
        public string NIC { get; set; }
        [StringLength(80)]
        public string Address { get; set; }
        public bool IsActive { get; set; }



    }
}
