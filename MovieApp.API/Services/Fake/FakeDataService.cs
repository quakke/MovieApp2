using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MovieApp.API.Models;

namespace MovieApp.API.Services.Fake
{
    public class FakeDataService : IDataService
    {
        public async Task<MovieDetailsResponse> GetMovieDetails()
        {
            //throw new NotImplementedException();
            MovieDetailsResponse result = new MovieDetailsResponse();

            result.Title = "Title";
            result.Description = "Description";

            return result;
        }

        public async Task<List<MovieResponseItem>> GetMovies()
        {
            //throw new NotImplementedException();
            List<MovieResponseItem> result = new List<MovieResponseItem>();

            result = new List<MovieResponseItem>();

            result.Add(new MovieResponseItem() { Title = "Title 1" });
            result.Add(new MovieResponseItem() { Title = "Title 2" });
            result.Add(new MovieResponseItem() { Title = "Title 3" });

            return result;
        }
    }
}
