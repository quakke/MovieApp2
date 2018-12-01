using System;
namespace MovieApp.API.Models
{
    public class MovieDetailsResponse
    {
        /// <summary>
        /// Название фильма
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Описание фильма
        /// </summary>
        public string Description { get; set; }

    }
}
