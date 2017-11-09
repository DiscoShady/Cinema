using System;
using System.Collections;
using System.Collections.Generic;

namespace Cinema.Models {

    public class MovieViewModel {
        public Movie Movie { get; set; }
        public List<Trailer> Trailer { get; set; }
    }

    public class Movie {
        public Movie() {
            AddedToDb = DateTime.Now;
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public string Tagline { get; set; }
        public int Runtime { get; set; }
        public string Release_date { get; set; }
        public string Poster_path { get; set; }
        public string Overview { get; set; }
        public string Original_title { get; set; }
        public string Original_language { get; set; }
        public string Imdb_id { get; set; }
        public string Backdrop_path { get; set; }
        public string Trailer_url { get; set; }
        public DateTime AddedToDb { get; set; }
        public DateTime StartDate { get; set; }

    }

    public class Trailer {
        public string iso_639_1 { get; set; }
        public string iso_3166_1 { get; set; }
        public string key { get; set; }
        public string name { get; set; }
    }
}