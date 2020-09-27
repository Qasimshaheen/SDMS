using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SDMS_API.Data
{
    public class Employee
    {
        public int Id { get; set; }
        public int? DepartmentId { get; set; }
        public int? ShiftId { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public DateTime HireDate { get; set; }
        public string FatherName { get; set; }
        [StringLength(10)]
        public string Gender { get; set; }
        [StringLength(15)]
        public string NIC { get; set; }
        [StringLength(80)]
        public string Address { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(13)]
        public string ContactNumber { get; set; }
        public bool IsActive { get; set; }
        [ForeignKey(nameof(ShiftId))]
        public Shift TblShift { get; set; }
        [ForeignKey(nameof(DepartmentId))]
        public Department TblDepartment { get; set; }
    }
}
