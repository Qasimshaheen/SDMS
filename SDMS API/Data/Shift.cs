using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SDMS_API.Data
{
    public class Shift
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
