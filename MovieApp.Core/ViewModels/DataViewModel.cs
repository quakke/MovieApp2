using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MovieApp.API.Models;
using MovieApp.API.Services;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.Platform;
using MvvmCross.Platform.Logging;

namespace MovieApp.Core.ViewModels
{
    public class DataViewModel : MvxViewModel<IMvxBundle>, IDataViewModel
    {
        #region Fields

        #endregion

        #region Commands

        private IMvxCommand _selectionChangedCommand;
        public IMvxCommand SelectionChangedCommand
        {
            get
            {
                return _selectionChangedCommand ?? (_selectionChangedCommand = new MvxCommand<MovieResponseItem>(OnMovieSelected));
            }
        }

        #endregion

        #region Properties

        private List<MovieResponseItem> _movies;
        public List<MovieResponseItem> Movies
        {
            get
            {
                return _movies;
            }
            private set
            {
                SetProperty(ref _movies, value);
            }
        }

        #endregion

        #region Services

        protected new IDataService DataService => Mvx.Resolve<IDataService>();

        #endregion

        #region Constructor

        public DataViewModel()
        {
        }

        #endregion

        #region Private

        //загрузка фильмов
        private async Task LoadContent()
        {
            try
            {
                var dataSource = await DataService.GetMovies();

                InvokeOnMainThread(() => Movies = dataSource);
            }
            catch(Exception ex)
            {
                MvxTrace.Error(() => ex.StackTrace);
            }
        }

        private void OnMovieSelected(MovieResponseItem item)
        {
            ShowViewModel<DataDetailsViewModel, MovieResponseItem>(item);
        }

        #endregion

        #region Protected

        #region Init

        public override void Prepare(IMvxBundle parameter)
        {
            //base.Prepare(parameter);

            //var navigationBundle = parameter.ReadAs<BaseBundle>();
            //this.InitFromBundle(navigationBundle);
        }

        #endregion

        #endregion

        #region Public

        public async Task Initialize()
        {
            await LoadContent();

            return;
        }

        #endregion
    }
}
