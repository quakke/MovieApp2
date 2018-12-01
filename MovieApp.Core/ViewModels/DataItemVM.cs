using System;
using MvvmCross.Core.ViewModels;

namespace MovieApp.Core.ViewModels
{
    public class DataItemVM : MvxViewModel, IDataItemVM
    {
        #region Properties

        public int VoteCount { get; protected set; }

        public int Id { get; protected set; }

        public string VoteAverage { get; protected set; }

        public string Title { get; protected set; }

        public string Popularity { get; protected set; }

        public string PosterPath { get; protected set; }

        public string OriginalLanguage { get; protected set; }

        public string OriginalTitle { get; protected set; }

        public string Overview { get; protected set; }

        public string ReleaseDate { get; protected set; }

        #endregion

        #region Constructor

        public DataItemVM(int vote_count, int id, string vote_average, string title, string popularity, string poster_path, string original_language, string original_title, string overview, string release_date)
        {
            VoteCount = vote_count;
            Id = id;
            VoteAverage = vote_average;
            Title = title;
            Popularity = popularity;
            PosterPath = poster_path;
            OriginalLanguage = original_language;
            OriginalTitle = original_title;
            Overview = overview;
            ReleaseDate = release_date;
        }

        #endregion
    }
}
