using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MovieApp.API.Models;
using MovieApp.API.Services;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.Platform;
using MvvmCross.Platform.Logging;
using System.Text;

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
                return _selectionChangedCommand ?? (_selectionChangedCommand = new MvxCommand<DataItemVM>(OnMovieSelected));
            }
        }

        #endregion

        #region Properties

        private List<DataItemVM> _movies;
        public List<DataItemVM> Movies
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

                Movies = new List<DataItemVM>();

                InvokeOnMainThread(() => 
                {
                    foreach(var item in dataSource)
                    {
                        StringBuilder desc = new StringBuilder();

                        desc.AppendLine("Название:");
                        desc.AppendLine(item.title);
                        desc.AppendLine("Средняя оценка:");
                        desc.AppendLine(item.vote_average);
                        desc.AppendLine("Количество голосов:");
                        desc.AppendLine(item.vote_count.ToString());
                        desc.AppendLine("Популярность:");
                        desc.AppendLine(item.popularity);
                        desc.AppendLine("Язык оригинала:");
                        desc.AppendLine(item.original_language);
                        desc.AppendLine("Оригинальное название:");
                        desc.AppendLine(item.original_title);
                        desc.AppendLine("Описание:");
                        desc.AppendLine(item.overview);
                        desc.AppendLine("Дата релиза:");
                        desc.AppendLine(item.release_date);

                        Movies.Add(new DataItemVM(
                            vote_count: item.vote_count,
                            id: item.id,
                            vote_average: item.vote_average,
                            title: item.title,
                            popularity: item.popularity,
                            poster_path: item.poster_path,
                            original_language: item.original_language,
                            original_title: item.original_title,
                            overview: item.overview,
                            release_date: item.release_date,
                            description: desc
                        ));
                    }
                });
            }
            catch(Exception ex)
            {
                MvxTrace.Error(() => ex.StackTrace);
            }
        }

        private void OnMovieSelected(DataItemVM item)
        {
            ShowViewModel<DataDetailsViewModel, DataItemVM>(item);
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
