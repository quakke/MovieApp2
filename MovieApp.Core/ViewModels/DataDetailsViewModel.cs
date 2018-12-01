using System;
using System.Threading.Tasks;
using MovieApp.API.Models;
using MovieApp.API.Services;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.Platform;

namespace MovieApp.Core.ViewModels
{
    public class DataDetailsViewModel : MvxViewModel<MovieResponseItem>
    {
        #region Fields

        #endregion

        #region Commands

        #endregion

        #region Properties

        private MovieResponseItem _movieItem;
        public MovieResponseItem MovieItem
        {
            get
            {
                return _movieItem;
            }
            private set
            {
                SetProperty(ref _movieItem, value);
            }
        }

        #endregion

        #region Services

        protected new IDataService DataService => Mvx.Resolve<IDataService>();

        #endregion

        #region Constructor

        public DataDetailsViewModel()
        {

        }

        #endregion

        #region Private

        //загрузка инфы о фильме
        private async Task LoadContent()
        {
            try
            {

            }
            catch (Exception ex)
            {
                MvxTrace.Error(() => ex.StackTrace);
            }
        }

        #endregion

        #region Protected

        #region Init

        public override void Prepare(MovieResponseItem parameter)
        {
            base.Prepare();

            MovieItem = parameter;
        }

        #endregion

        #endregion

        #region Public


        public override async Task Initialize()
        {
            await LoadContent();

            await base.Initialize();

            return;
        }

        #endregion


    }
}
