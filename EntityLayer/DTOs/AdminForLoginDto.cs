using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTOs
{
    public class AdminForLoginDto
    {
        public int LoginID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
