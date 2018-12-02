using System;
using System.Collections.Generic;
using Realms;

namespace MovieApp.API.Models
{
    public class MoviesResponse : RealmObject
    {
        public string page { get; set; }

        public IList<MovieResponseItem> results { get; }
    }
}
