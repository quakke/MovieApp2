using System;
using System.Text;
using MovieApp.API.Models;
using MovieApp.Core.ViewModels;
namespace MovieApp.Core.Services.Implementation
{
    public class HistoryDataService : DataBaseService<MovieResponseItem, DataItemVM, string>, IHistoryDataService
    {
        protected override DataItemVM ConvertFromDBO(MovieResponseItem item)
        {
            StringBuilder desc = new StringBuilder();

            desc.AppendLine("Название:").AppendLine(!String.IsNullOrWhiteSpace(item.title) ? item.title : "");
            desc.AppendLine("Средняя оценка:").AppendLine(!String.IsNullOrWhiteSpace(item.vote_average) ? item.vote_average : "");
            desc.AppendLine("Количество голосов:").AppendLine(!String.IsNullOrWhiteSpace(item.vote_count) ? item.vote_count : "");
            desc.AppendLine("Популярность:").AppendLine(!String.IsNullOrWhiteSpace(item.popularity) ? item.popularity : "");
            desc.AppendLine("Язык оригинала:").AppendLine(!String.IsNullOrWhiteSpace(item.original_language) ? item.original_language : "");
            desc.AppendLine("Оригинальное название:").AppendLine(!String.IsNullOrWhiteSpace(item.original_title) ? item.original_title : "");
            desc.AppendLine("Описание:").AppendLine(!String.IsNullOrWhiteSpace(item.overview) ? item.overview : "");
            desc.AppendLine("Дата релиза:").AppendLine(!String.IsNullOrWhiteSpace(item.release_date) ? DateTime.Parse(item.release_date).ToString() : "");

            return new DataItemVM(item.id, item.title, item.poster_path, desc);
        }

        protected override MovieResponseItem ConvertToDBO(MovieResponseItem dbo, DataItemVM model)
        {
            return new MovieResponseItem
            {
                id = model.Id,
                title = model.Title,
                poster_path = model.PosterPath
            };
        }

        protected override string GetId(DataItemVM model)
        {
            return model.Id;
        }

        protected override string GetId(MovieResponseItem dbo)
        {
            return dbo.id;
        }
    }
}
