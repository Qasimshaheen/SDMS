using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.Data
{
    public class Product
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int MeasureUnitID { get; set; }


        [StringLength(20)]
        public string Code { get; set; }

        public decimal RetailPrice { get; set; }
        public decimal ActualPrice { get; set; }

        [StringLength(100)]
        public string Remarks { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }




        [ForeignKey(nameof(MeasureUnitID))]
        public MeasureUnit TblMeasureUnit { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public ProductCategory TblProductCategory { get; set; }

    }
}
