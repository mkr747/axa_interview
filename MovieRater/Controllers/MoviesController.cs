using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieRater.Models;
using MovieRater.Services;

namespace MovieRater.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        // GET: MoviesController
        public async Task<ActionResult> Index()
        {
            var entity = await _movieService.GetMovies();
            var movies = entity.Select(x => new MovieViewModel
            {
                Id = x.Id,
                Title = x.Title
            });

            return View(movies);
        }

        [Route("Movies/{id:int}")]
        public async Task<ActionResult> Details(int id)
        {
            var details = await _movieService.FetchMovieDetails(id);

            return View(details);
        }

        public ActionResult GetRatePartial(int id) =>
            PartialView("_RatePartial", new RateViewModel
            {
                MovieId = id
            });

        [HttpPost]
        public async Task<ActionResult> Rate([Bind("MovieId, Value")] RateViewModel rate)
        {
            await _movieService.RateMovie(rate.MovieId, rate.Value);

            return Json(new
            {
                Status = true,
                Message = "Succesfully saved"
            });
        }
    }
}
