using System;
using System.Collections.Generic;

namespace MovieApp.API.Models
{
    public class MoviesResponse
    {
        public string page { get; set; }

        public List<MovieResponseItem> results { get; set; }
    }
}
