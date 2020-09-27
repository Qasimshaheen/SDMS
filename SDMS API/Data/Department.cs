using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace SDMS_API.Data
{
    public class Department
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
