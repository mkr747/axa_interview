using DataAccess.Entities;
using System.Collections.Generic;

namespace DataAccess
{
    public static class Seed
    {
        private static readonly string _api = "https://swapi.dev/api/films/";

        public static IEnumerable<Movie> Get()
            => new List<Movie>
            {
                new Movie { Address = $"{_api}1/", Id = 1, Title = "A New Hope"},
                new Movie { Address = $"{_api}2/", Id = 2, Title = "The Empire Strikes Back"},
                new Movie { Address = $"{_api}3/", Id = 3, Title = "Return of the Jedi"},
                new Movie { Address = $"{_api}4/", Id = 4, Title = "The Phantom Menace"},
                new Movie { Address = $"{_api}5/", Id = 5, Title = "Attack of the Clones"},
                new Movie { Address = $"{_api}6/", Id = 6, Title = "Revenge of the Sith"},
            };
    }
}
