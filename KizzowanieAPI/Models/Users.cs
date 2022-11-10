using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace KizzowanieAPI
{
    public partial class Users
    {
        public Users()
        {
            BasicKizz = new HashSet<BasicKizz>();
        }

        public int UserId { get; set; }
        public string UserEmail { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }

        public virtual ICollection<BasicKizz> BasicKizz { get; set; }
    }
}
