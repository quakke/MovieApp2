using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using MovieApp.API.Models;
using Newtonsoft.Json;

namespace MovieApp.API.Services.Implementation
{
    public class DataService : IDataService
    {
        protected string GET_MOVIES_URL = "https://api.themoviedb.org/3/movie/popular?api_key=e119b30526ac3ac9490972484ad7077a&language=en-US&page=";

        public async Task<List<MovieResponseItem>> GetMovies()
        {
            int page = 1;

            var url = ($"{GET_MOVIES_URL}{page}");

            HttpClientHandler handler = new HttpClientHandler();

            var httpClient = new HttpClient(handler);

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);

            HttpResponseMessage response = await httpClient.SendAsync(request);

            var json = await response.Content.ReadAsStringAsync();

            List<MovieResponseItem> result = new List<MovieResponseItem>();

            var jsonDeserealize = JsonConvert.DeserializeObject<MoviesResponse>(json);

            return jsonDeserealize.results;
        }
    }
}
