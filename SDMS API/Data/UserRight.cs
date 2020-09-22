using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SDMS_API.Data
{
    public class UserRight
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
        public int MenueId { get; set; }
        [ForeignKey(nameof(MenueId))]
        public Menue Menue { get; set; }
        public bool IsAllow { get; set; }
        public bool IsPost { get; set; }

    }
}
