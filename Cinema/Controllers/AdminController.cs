using Cinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cinema.Controllers {
    public class AdminController : Controller {
        // GET: Admin
        public ActionResult Index() {
            return View();
        }
        public ActionResult AddMovie() {
            return View();
        }

        [HttpPost]
        public ActionResult AddMovie(string searchString) {
            var tmdb = new Tmdb();
            var getResults = Tmdb.GetMovieSearchResults(searchString);
            if (getResults != null) {
                ViewBag.ResultStatus = "OK";
                return View(getResults);
            }else{
                ViewBag.ResultStatus = "ERR";
            }
            // "w92", "w154", "w185", "w342", "w500", "w780", or "original";
            return View();
        }

        public ActionResult NewListing() {
            return View();
        }

        [HttpGet]
        public async System.Threading.Tasks.Task<ActionResult> NewListing(string Title, MovieViewModel mv) {
            Tmdb tmdb = new Tmdb();

            var movieId = tmdb.GetMovieId(Title);
            var movie = await tmdb.GetMovie(movieId);
            var trailers = Tmdb.GetTrailers(Convert.ToInt32(movieId));

            mv.Movie = movie;
            mv.Trailer = trailers;

            return View(mv);
        }

    }
}