using System;
using System.Threading.Tasks;
using MovieApp.API.Models;
using MovieApp.API.Services;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.Platform;

namespace MovieApp.Core.ViewModels
{
    public class DataDetailsViewModel : MvxViewModel<DataItemVM>
    {
        #region Fields

        #endregion

        #region Commands

        #endregion

        #region Properties

        private DataItemVM _movieItem;
        public DataItemVM MovieItem
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

        #endregion

        #region Constructor

        public DataDetailsViewModel()
        {

        }

        #endregion

        #region Private

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

        public override void Prepare(DataItemVM parameter)
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
