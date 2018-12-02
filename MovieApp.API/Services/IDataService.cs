using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MovieApp.API.Models;

namespace MovieApp.API.Services
{
    public interface IDataService
    {
        // Получить список всех фильмов
        Task<IList<MovieResponseItem>> GetMovies(int page);
    }
}
