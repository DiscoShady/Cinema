using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Cinema.Models {
    public class Tmdb {
        const string tmdbUrl = "https://api.themoviedb.org/3/movie/";
        const string tmdbSearchUrl = "https://api.themoviedb.org/3/search/movie";
        public Movie newMovie; // Initialize movie object
        const string apiKey = "66195db594b6fa3cea5439900dd38335";


        public static List<string> GetMovieSearchResults(string searchString) {
            using (WebClient wc = new WebClient()) {
                var findMovieId = wc.DownloadString(tmdbSearchUrl + "?api_key=" + apiKey + "&query=" + searchString);
                List<string> result = new List<string>();
                dynamic jsonObject = JObject.Parse(findMovieId);
                foreach (var station in jsonObject.results) {
                    result.Add(station.title.ToString());
                }
                return result;
            }
            //http://stackoverflow.com/questions/36482299/how-do-i-select-same-name-json-objects-c-sharp-asp-net
        }

        public static List<string> GetMoviePosters(string imdb_id) {
            using (WebClient wc = new WebClient()) {
                var getPosters = wc.DownloadString(tmdbUrl + imdb_id + "/images?api_key=" + apiKey);
                List<string> result = new List<string>();
                dynamic jsonObject = JObject.Parse(getPosters);
                foreach (var station in jsonObject.posters) {
                    result.Add(station.file_path.ToString());
                }

                return result;
            }
        }

        public string GetMovieId(string name) {
            using (WebClient wc = new WebClient()) {
                var findMovieId = wc.DownloadString(tmdbSearchUrl + "?api_key=" + apiKey + "&query=" + name);
                var movieId = JObject.Parse(findMovieId)["results"][0]["id"];
                name = movieId.ToString();
                return name;
            }
        }

        public async Task<Movie> GetMovie(string query) {
            using (var client = new HttpClient()) {
                client.BaseAddress = new Uri(tmdbUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync(tmdbUrl + query + "?api_key=" + apiKey);
                if (response.IsSuccessStatusCode) {
                    newMovie = await response.Content.ReadAsAsync<Movie>();

                    return newMovie;
                } else {
                    return null;
                }
            }
        }
    }
}
//https://api.themoviedb.org/3/search/movie?api_key=66195db594b6fa3cea5439900dd38335&query=The%20Martian
//https://api.themoviedb.org/3/movie/286217?api_key=66195db594b6fa3cea5439900dd38335