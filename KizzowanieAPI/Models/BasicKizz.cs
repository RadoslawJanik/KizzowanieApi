using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace KizzowanieAPI
{
    public partial class BasicKizz
    {
        public int BasicKizzId { get; set; }
        public string BasicKizzTitile { get; set; }
        public string BasicKizzIntro { get; set; }
        public TimeSpan? BasicKizzTime { get; set; }
        public int? BasicKizzTakesCounter { get; set; }
        public int BkquestionId { get; set; }
        public int? UserId { get; set; }
        public string ImgName { get; set; }

        public virtual Bkquestion Bkquestion { get; set; }
        public virtual Users User { get; set; }
    }
}
