using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema.Models {
    public class MovieViewModel {
        public Movie Movie { get; set; }
        public List<Trailer> Trailer { get; set; }
        public Listing Listing { get; set; }
        public Screen Screen { get; set; }
    }
}