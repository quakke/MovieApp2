using System;
using System.Text;

namespace MovieApp.Core.ViewModels
{
    public interface IDataItemVM
    {
        int Id { get; }

        string Title { get; }

        string PosterPath { get; }

        StringBuilder Description { get; }
    }
}
