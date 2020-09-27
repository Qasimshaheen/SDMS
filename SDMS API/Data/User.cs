using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SDMS_API.Data
{
    public class User
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Username { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public List<UserRight> UserRights { get; set; }
        [InverseProperty("TblAddedByUser")]
        public List<VoucherMaster> TblVoucherMastersAddedBy { get; set; }
        [InverseProperty("TblUpdatedByUser")]
        public List<VoucherMaster> TblVoucherMastersUpdatedBy { get; set; }
        [InverseProperty("TblAddedByUser")]
        public List<ProductLedger> TblProductLedgerAddedBy { get; set; }
        [InverseProperty("TblUpdatedByUser")]
        public List<ProductLedger> TblProductLedgersUpdatedBy { get; set; }
        [InverseProperty("TblAddedByUser")]
        public List<ManufacturingMaster> TblManufacturingMasterAddedBy { get; set; }
        [InverseProperty("TblUpdatedByUser")]
        public List<ManufacturingMaster> TblManufacturingMasterUpdatedBy { get; set; }
        [InverseProperty("TblAddedByUser")]
        public List<PurchaseMaster> TblPurchaseMastersAddedBy { get; set; }
        [InverseProperty("TblUpdatedByUser")]
        public List<PurchaseMaster> TblPurchaseMastersUpdatedBy { get; set; }

    }
}
