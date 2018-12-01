using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MovieApp.API.Models;

namespace MovieApp.API.Services
{
    public interface IDataService
    {
        // Получить список всех фильмов
        Task<List<MovieResponseItem>> GetMovies();

        // Полчить информацию по одному фильму
        Task<MovieDetailsResponse> GetMovieDetails();

    }
}
