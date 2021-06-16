using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }
        public string AdminUserName { get; set; }
        public byte[] AdminUserNameHash { get; set; }
        public byte[] AdminUserNameSalt { get; set; }
        public byte[] AdminPasswordHash { get; set; }
        public byte[] AdminPasswordSalt { get; set; }

        [StringLength(1)]
        public string AdminRole { get; set; }

    }
}
