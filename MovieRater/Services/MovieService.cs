using DataAccess;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using MovieRater.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MovieRater.Services
{
    public class MovieService : IMovieService
    {
        private readonly IDbContextFactory<MovieContext> _contextFactory;
        private readonly HttpClient _client;

        public MovieService(HttpClient client, IDbContextFactory<MovieContext> contextFactory)
        {
            _contextFactory = contextFactory;
            _client = client;
        }

        public async Task<MovieDetailsViewModel> FetchMovieDetails(int id)
        {
            using var context = _contextFactory.CreateDbContext();
            var movie = context.Movies.Include(p => p.Rates).FirstOrDefault(x => x.Id == id);
            var rate = movie.Rates?.Select(x => x.Value).Average();

            var httpReponse = await _client.GetAsync(movie.Address);
            var content = await httpReponse.Content.ReadAsStringAsync();
            var movieDetails = JsonConvert.DeserializeObject<MovieSWAPI>(content);

            var details = new MovieDetailsViewModel
            {
                Id = id,
                Created = movieDetails.Created,
                Director = movieDetails.Director,
                Edited = movieDetails.Edited,
                Opening_crawl = movieDetails.Opening_crawl,
                Producer = movieDetails.Producer,
                Release_date = movieDetails.Release_date,
                Title = movieDetails.Title,
                Rate = rate ?? 0
            };

            return details;
        }

        public async Task<IEnumerable<Movie>> GetMovies()
        {
            using var context = _contextFactory.CreateDbContext();
            var movies = await context.Movies.ToListAsync();

            return movies;
        }

        public async Task RateMovie(int movieId, int value)
        {
            using var context = _contextFactory.CreateDbContext();
            var movie = context.Movies.Find(movieId);
            var rate = new Rate
            {
                Movie = movie,
                MovieId = movieId,
                Value = value,
            };

            context.Rates.Add(rate);
            await context.SaveChangesAsync();
        }
    }
}
