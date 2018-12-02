using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Realms;

namespace MovieApp.Core.Services.Implementation
{
    public abstract class DataBaseService<TDbo, TModel, ID> : IDataBaseService<TModel, ID>
        where TDbo : RealmObject, new()
        where TModel : class
        where ID : IComparable, IComparable<ID>, IEquatable<ID>
    {
        protected readonly ID BAD_ID = default(ID);

        protected virtual RealmConfiguration Configuration
        {
            get
            {
                return new RealmConfiguration(DBName)
                {
                    ObjectClasses = new[] { typeof(TDbo) },
                    SchemaVersion = 1,
                    //MigrationCallback = HandleMigrationCallbackDelegate
                };
            }
        }

        protected Realm Instance { get { return Realm.GetInstance(Configuration); } }

        public virtual string DBName { get { return "database.realm"; } }

        protected DataBaseService()
        {

        }

        protected virtual void HandleMigrationCallbackDelegate(Migration migration, ulong oldSchemaVersion)
        {

        }

        protected Expression<Func<TDbo, bool>> IdentifyModelByIdInArray(IEnumerable<ID> enumerable)
        {
            return dbo => enumerable.Contains(GetId(dbo));
        }

        protected Func<TDbo, bool> EqualDboToModel(TModel model)
        {
            return (arg) => GetId(arg).Equals(GetId(model));
        }

        #region Abstract

        protected abstract TDbo ConvertToDBO(TDbo dbo, TModel model);
        protected abstract TModel ConvertFromDBO(TDbo dbo);

        protected abstract ID GetId(TModel model);
        protected abstract ID GetId(TDbo dbo);

        #endregion

        #region IDataBaseService implementation

        public int Count()
        {
            return Instance.All<TDbo>().Count();
        }

        #region IsertOrUpdate

        public void InsertOrUpdate(TModel model)
        {
            TDbo existsDbo = null;

            lock (this)
            {
                var allDbo = Instance.All<TDbo>();
                existsDbo = allDbo != null && allDbo.Any() ? allDbo.FirstOrDefault(EqualDboToModel(model)) : null;

                using (var transaction = Instance.BeginWrite())
                {
                    Instance.Add(ConvertToDBO(existsDbo, model), existsDbo != null);

                    transaction.Commit();
                }
            }
        }

        public void InsertOrUpdate(IEnumerable<TModel> models)
        {
            var update = true;

            lock (this)
            {
                using (var transaction = Instance.BeginWrite())
                {
                    foreach (var model in models)
                    {
                        var allDbo = Instance.All<TDbo>();
                        var existsDbo = allDbo != null && allDbo.Any() ? allDbo.FirstOrDefault(EqualDboToModel(model)) : null;

                        Instance.Add(ConvertToDBO(existsDbo, model), existsDbo != null);

                        if (update && existsDbo == null)
                            update = false;


                    }
                    transaction.Commit();
                }
            }
        }

        #endregion

        #region Load

        public TModel LoadById(ID id)
        {
            TDbo existsDbo = null;

            lock (this)
            {
                existsDbo = Instance.All<TDbo>().FirstOrDefault(dbo => GetId(dbo).Equals(id));
            }

            return ConvertFromDBO(existsDbo);
        }

        public IEnumerable<TModel> LoadAll()
        {
            IEnumerable<TModel> models;

            lock (this)
            {
                models = Instance.All<TDbo>().Select(ConvertFromDBO);
            }

            return models;
        }

        public IEnumerable<TModel> LoadAll(int skip, int count = 10)
        {
            if (skip <= 0)
                skip = 0;

            if (count <= 0)
                count = 10;

            IEnumerable<TModel> models;

            lock (this)
            {
                models = Instance.All<TDbo>().Skip(skip).Take(count).Select(ConvertFromDBO);
            }

            return models;
        }

        #endregion

        #region Delete

        public void Delete(ID id)
        {
            if ((id == null && BAD_ID == null) || id.Equals(BAD_ID))
                return;

            TDbo deletedItem = null;

            lock (this)
            {
                deletedItem = Instance.All<TDbo>().FirstOrDefault(d => GetId(d).Equals(id));

                using (var transaction = Instance.BeginWrite())
                {
                    Instance.Remove(deletedItem);
                    transaction.Commit();
                }
            }
        }

        public void Delete(TModel model)
        {
            Delete(GetId(model));
        }

        public void DeleteAll()
        {
            var deletedItems = new List<TModel>();

            lock (this)
            {
                deletedItems = Instance.All<TDbo>().Select(ConvertFromDBO).ToList();
                using (var transaction = Instance.BeginWrite())
                {
                    Instance.RemoveAll();
                    transaction.Commit();
                }
            }
        }

        public void DeleteAllMatches(Expression<Func<TModel, bool>> predicate)
        {
            var deletedItems = new List<TModel>();

            lock (this)
            {
                var data = Instance.All<TDbo>().Where(dbo => predicate.Compile().Invoke(ConvertFromDBO(dbo))).ToList();
                using (var transaction = Instance.BeginWrite())
                {
                    foreach (var item in data)
                    {
                        deletedItems.Add(ConvertFromDBO(item));
                        Instance.Remove(item);
                    }

                    transaction.Commit();
                }
            }
        }

        #endregion

        #endregion
    }
}