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

            desc.AppendLine("Название:").AppendLine(item.title);
            desc.AppendLine("Средняя оценка:").AppendLine(item.vote_average);
            desc.AppendLine("Количество голосов:").AppendLine(item.vote_count.ToString());
            desc.AppendLine("Популярность:").AppendLine(item.popularity);
            desc.AppendLine("Язык оригинала:").AppendLine(item.original_language);
            desc.AppendLine("Оригинальное название:").AppendLine(item.original_title);
            desc.AppendLine("Описание:").AppendLine(item.overview);
            desc.AppendLine("Дата релиза:").AppendLine(DateTime.Parse(item.release_date).ToString());

            return new DataItemVM(item.id, item.title, item.poster_path, desc);
        }

        protected override MovieResponseItem ConvertToDBO(MovieResponseItem dbo, DataItemVM model)
        {
            return dbo;
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
