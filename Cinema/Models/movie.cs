using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cinema.Models {
    public class Movie {
        public Movie() {
            AddedToDb = DateTime.Now;
            Hidden = false;
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Video { get; set; }
        public string Status { get; set; }
        public string Tagline { get; set; }
        public int Runtime { get; set; }
        public string Release_date { get; set; }
        public int Revenue { get; set; }
        public string Poster_path { get; set; }
        public string Overview { get; set; }
        public string Original_title { get; set; }
        public string Original_language { get; set; }
        public string Imdb_id { get; set; }
        public string Backdrop_path { get; set; }
        public DateTime AddedToDb { get; set; }
        public bool Hidden { get; set; }
    }
}