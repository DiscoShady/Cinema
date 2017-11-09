using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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


        public static List<Movie> GetMovieSearchResults(string searchString) {
            var json = new WebClient().DownloadString(tmdbSearchUrl + "?api_key=" + apiKey + "&query=" + searchString);
            var GetResults = JObject.Parse(json)["results"].ToObject<ObservableCollection<Movie>>().ToList();
        
            return GetResults;
        }

       public static List<Trailer> GetTrailers (int movieId) {
            var json = new WebClient().DownloadString(tmdbUrl + movieId + "/videos?api_key=" + apiKey);
            var GetResults = JObject.Parse(json)["results"].ToObject<ObservableCollection<Trailer>>().ToList();

            return GetResults;
        }



        public static List<string> GetMoviePosters(string imdb_id) {
            using (WebClient wc = new WebClient()) {
                var getPosters = wc.DownloadString(tmdbUrl + imdb_id + "/images?api_key=" + apiKey);
                List<string> result = new List<string>();
                dynamic jsonObject = JObject.Parse(getPosters);
                foreach (var poster in jsonObject.posters) {
                    result.Add(poster.file_path.ToString());
                }

                return result;
            }
        }

        public static List<string> GetCast(int movieId) {
            using (WebClient wc = new WebClient()) {
                var findMovieId = wc.DownloadString(tmdbUrl + movieId + "/credits?api_key=" + apiKey);
                List<string> result = new List<string>();
                dynamic jsonObject = JObject.Parse(findMovieId);
                foreach (var cast in jsonObject["cast"]) {
                    result.Add(cast["character"].ToString());
                    result.Add(cast["name"].ToString());
                    result.Add(cast["profile_path"].ToString());
                    result.Add(cast["credit_id"].ToString());

                }
                return result;
            }
            //http://stackoverflow.com/questions/36482299/how-do-i-select-same-name-json-objects-c-sharp-asp-net
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
                HttpResponseMessage response = await client.GetAsync(tmdbUrl + query + "?api_key=" + apiKey + "&append_to_response=videos");
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
//https://api.themoviedb.org/3/movie/284053?api_key=66195db594b6fa3cea5439900dd38335