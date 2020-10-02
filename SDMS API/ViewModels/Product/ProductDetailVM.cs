using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.ViewModels.Product
{
    public class ProductDetailVM
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string CategoryName { get; set; }
        public string MeasureUnitName { get; set; }
        public string Remarks { get; set; }
        public string Status { get; set; }
    }
}
