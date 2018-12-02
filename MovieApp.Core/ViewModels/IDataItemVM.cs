using System;
using System.Text;

namespace MovieApp.Core.ViewModels
{
    public interface IDataItemVM 
    {
        string Id { get; }

        string Title { get; }

        string PosterPath { get; }

        StringBuilder Description { get; }
    }
}
