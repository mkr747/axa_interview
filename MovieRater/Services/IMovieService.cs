using DataAccess.Entities;
using MovieRater.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieRater.Services
{
    public interface IMovieService
    {
        Task<MovieDetailsViewModel> FetchMovieDetails(int id);
        
        Task<IEnumerable<Movie>> GetMovies();

        Task RateMovie(int movieId, int value);
    }
}