using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodordering.Models
{
    public class Address
    {
        public int id { get; set; }
        public string street { get; set; }
        public string city { get; set; }
        public string zipcode { get; set; }
       // public Location Location { get; set; }
    }
}
