using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodordering.Models
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public long phoneno { get; set; }
        public  Address address { get; set; }

    }
}
