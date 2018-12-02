using System;
using Realms;

namespace MovieApp.API.Models
{
    public class MovieResponseItem : RealmObject
    {
        public int vote_count { get; set; }

        public int id { get; set; }

        public string vote_average { get; set; }

        public string title { get; set; }

        public string popularity { get; set; }

        public string poster_path { get; set; }

        public string original_language { get; set; }

        public string original_title { get; set; }

        public string overview { get; set; }

        public string release_date { get; set; }
    }
}
