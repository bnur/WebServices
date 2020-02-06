using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Services.Models
{
    public class ForeignTC
    {
        public long TCKN { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int BirthDay { get; set; }
        public int BirthMonth { get; set; }
        public int BirthYear { get; set; }
    }
}