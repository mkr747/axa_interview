using System;

namespace MovieRater.Models
{
    public class MovieDetailsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Producer { get; set; }
        
        public string Release_date { get; set; }
        
        public string Director { get; set; }
        
        public string Opening_crawl { get; set; }
        
        public DateTime Created { get; set; }
        
        public DateTime Edited { get; set; }

        public double Rate { get; set; }
    }
}
