using System.ComponentModel.DataAnnotations;

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
    }
}
