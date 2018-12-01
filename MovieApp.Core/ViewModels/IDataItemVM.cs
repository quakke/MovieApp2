using System;
namespace MovieApp.Core.ViewModels
{
    public interface IDataItemVM
    {
        string Id { get; }

        string Title { get; }

        string Description { get; }

        string ImageUrl { get; }
    }
}
