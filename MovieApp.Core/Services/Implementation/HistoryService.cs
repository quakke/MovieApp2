using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using MovieApp.API.Models;
using MovieApp.Core.ViewModels;
using Realms;

namespace MovieApp.Core.Services.Implementation
{
    public class HistoryService : IHistoryService
    {
        protected virtual RealmConfiguration Configuration
        {
            get
            {
                return new RealmConfiguration(DBName)
                {
                    ObjectClasses = new[] { typeof(MovieResponseItem) },
                    SchemaVersion = 1,
                    MigrationCallback = HandleMigrationCallbackDelegate
                };
            }
        }

        protected Realm Instance { get { return Realm.GetInstance(Configuration); } }

        public virtual string DBName { get { return "database.realm"; } }

        public HistoryService()
        {

        }

        protected virtual void HandleMigrationCallbackDelegate(Migration migration, ulong oldSchemaVersion)
        {

        }

        #region IDataBaseService implementation

        public int Count()
        {
            return Instance.All<MovieResponseItem>().Count();
        }

        #region IsertOrUpdate

        public void InsertOrUpdate(DataItemVM model)
        {
            MovieResponseItem existsDbo = null;

            lock (this)
            {
                var allDbo = Instance.All<MovieResponseItem>();
                existsDbo = allDbo != null && allDbo.Any() ? allDbo.FirstOrDefault(EqualDboToModel(model)) : null;

                using (var transaction = Instance.BeginWrite())
                {
                    Instance.Add(ConvertToDBO(existsDbo, model), existsDbo != null);

                    transaction.Commit();
                }
            }
        }

        protected Func<MovieResponseItem, bool> EqualDboToModel(DataItemVM model)
        {
            return (arg) => GetId(arg).Equals(GetId(model));
        }

        #endregion

        #region Load

        public DataItemVM LoadById(string id)
        {
            MovieResponseItem existsDbo = null;

            lock (this)
            {
                existsDbo = Instance.All<MovieResponseItem>().FirstOrDefault(dbo => GetId(dbo).Equals(id));
            }

            return ConvertFromDBO(existsDbo);
        }

        public IEnumerable<DataItemVM> LoadAll()
        {
            IEnumerable<DataItemVM> models;

            lock (this)
            {
                models = Instance.All<MovieResponseItem>().Select(ConvertFromDBO);
            }

            return models;
        }

        #endregion

        #region Delete

        public void DeleteAll()
        {
            var deletedItems = new List<DataItemVM>();

            lock (this)
            {
                deletedItems = Instance.All<MovieResponseItem>().Select(ConvertFromDBO).ToList();
                using (var transaction = Instance.BeginWrite())
                {
                    Instance.RemoveAll();
                    transaction.Commit();
                }
            }
        }


        #endregion

        #endregion

        protected DataItemVM ConvertFromDBO(MovieResponseItem item)
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

        protected MovieResponseItem ConvertToDBO(MovieResponseItem dbo, DataItemVM model)
        {
            return new MovieResponseItem
            {
                id = model.Id,
                title = model.Title,
                poster_path = model.PosterPath
            };
        }

        protected string GetId(DataItemVM model)
        {
            return model.Id;
        }

        protected string GetId(MovieResponseItem dbo)
        {
            return dbo.id;
        }
    }
}