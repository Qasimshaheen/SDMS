using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.Data
{
    public class Menu
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public bool IsReport { get; set; }
        public int? ParentMenueId { get; set; }
        [ForeignKey(nameof(ParentMenueId))]
        public Menu TblParentMenue { get; set; }
        public List<Menu> TblChildMenues { get; set; }
        public List<UserRight> UserRights { get; set; }


    }
}
