using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MovieApp.Core.ViewModels;

namespace MovieApp.Core.Services
{
    public interface IHistoryService
    {
        string DBName { get; }

        void InsertOrUpdate(DataItemVM model);

        IEnumerable<DataItemVM> LoadAll();

        void DeleteAll();
    }
}
