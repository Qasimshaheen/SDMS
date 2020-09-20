using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SDMS_API.Data
{
    public class MeasureUnit
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public List<Product> Products { get; set; }

    }
}
