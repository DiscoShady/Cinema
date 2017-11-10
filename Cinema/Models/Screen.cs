using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema.Models{
    public class Screen{
        public Screen() {
            IMAX = false;
            ATMOS = false;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Seat> Seat { get; set; }
        public string SoundSystem { get; set; }
        public string OtherInfo { get; set; }
        public bool IMAX { get; set; } //IMAX screen. Default to false.
        public bool ATMOS { get; set; } //ATMOS sound system, not that thing from Doctor Who. Default to false.
        public ICollection<Listing> Listing { get; set; }
    }
}