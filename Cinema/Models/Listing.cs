using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema.Models {
    public class Listing {
        public int Id { get; set; }
        public Screen Screen { get; set; }
        public int Price { get; set; } //make a default price somewhere
        public DateTime PlayTime { get; set; }
    }
}