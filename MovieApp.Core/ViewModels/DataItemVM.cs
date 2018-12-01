using System;
using MvvmCross.Core.ViewModels;

namespace MovieApp.Core.ViewModels
{
    public class DataItemVM : MvxViewModel, IDataItemVM
    {
        #region Properties

        public string Id { get; protected set; }

        public string Title { get; protected set; }

        public string Description { get; protected set; }

        public string ImageUrl { get; protected set; }

        #endregion

        #region Constructor

        public DataItemVM(string id, string title, string description, string imageUrl)
        {
            Id = id;
            Title = title;
            Description = description;
            ImageUrl = imageUrl;
        }

        #endregion
    }
}
