using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Skill
    {
        public int SkillID { get; set; }
        public string SkillName { get; set; }
        public string Degree { get; set; }
        public int? WriterID { get; set; }
        public virtual Writer Writer { get; set; }

    }
}
