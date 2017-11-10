using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema.Models {
    public class Seat {
        public Seat() {
            Booked = false;
            Normal = true;
            Sofa = false;
            VIP = false;
            Handicap = false;
        }
        public int Id { get; set; }
        public bool Booked { get; set; }
        public bool Normal { get; set; }
        public bool Sofa { get; set; }
        public bool VIP { get; set; }
        public bool Handicap { get; set; }
        public Screen Screen { get; set; }
    }
}