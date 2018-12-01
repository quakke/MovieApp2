using System;
using System.Text;

namespace MovieApp.Core.ViewModels
{
    public interface IDataItemVM
    {
        int VoteCount { get; }

        int Id { get; }

        string VoteAverage { get; }

        string Title { get; }

        string Popularity { get; }

        string PosterPath { get; }

        string OriginalLanguage { get; }

        string OriginalTitle { get; }

        string Overview { get; }

        string ReleaseDate { get; }

        StringBuilder Description { get; }
    }
}
