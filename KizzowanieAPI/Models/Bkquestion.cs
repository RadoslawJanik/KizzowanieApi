using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace KizzowanieAPI
{
    public partial class Bkquestion
    {
        public Bkquestion()
        {
            BasicKizz = new HashSet<BasicKizz>();
        }

        public int BkquestionId { get; set; }
        public string Bkhint { get; set; }
        public string Bkanswer { get; set; }

        public virtual ICollection<BasicKizz> BasicKizz { get; set; }
    }
}
