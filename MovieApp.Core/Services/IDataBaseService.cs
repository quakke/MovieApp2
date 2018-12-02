using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MovieApp.Core.Services
{
    public interface IDataBaseService
    {
        string DBName { get; }
    }

    public interface IDataBaseService<TModel, ID> : IDataBaseService
        where TModel : class
        where ID : IComparable, IComparable<ID>, IEquatable<ID>
    {
        int Count();

        void InsertOrUpdate(TModel model);

        void InsertOrUpdate(IEnumerable<TModel> model);

        TModel LoadById(ID id);

        IEnumerable<TModel> LoadAll();

        IEnumerable<TModel> LoadAll(int skip, int count = 20);

        void Delete(ID id);

        void Delete(TModel model);

        void DeleteAll();

        void DeleteAllMatches(Expression<Func<TModel, bool>> predicate);
    }
}
