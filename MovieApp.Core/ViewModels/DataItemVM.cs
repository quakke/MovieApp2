using System;
using System.Text;
using MvvmCross.Core.ViewModels;

namespace MovieApp.Core.ViewModels
{
    public class DataItemVM : MvxViewModel, IDataItemVM
    {
        #region Properties

        public string Id { get; protected set; }

        public string Title { get; protected set; }

        public string PosterPath { get; protected set; }

        public StringBuilder Description { get; protected set; }

        #endregion

        #region Constructor

        public DataItemVM(string id, string title, string posterPath, StringBuilder description)
        {
            Id = id;
            Title = title;
            PosterPath = posterPath;
            Description = description;
        }

        #endregion
    }
}
