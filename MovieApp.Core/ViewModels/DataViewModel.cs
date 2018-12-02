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

        private int countOfPages = 10;

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

        private bool _loading;
        public virtual bool Loading
        {
            get
            {
                return _loading;
            }
            set
            {
                _loading = value;
                InvokeOnMainThread(() => RaisePropertyChanged(() => Loading));
            }
        }

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
            Loading = false;

            try
            {
                // TODO: конечно, по-хорошему, подгружать данные тогда, когда сроллим страницу. Но пока оставлю так
                // переделаю, если останется время
                List<MovieResponseItem> param = new List<MovieResponseItem>();
                for (var i = 1; i <= countOfPages; i++)
                {
                    var dataSource = await DataService.GetMovies(i);
                    param.AddRange(dataSource);
                }

                Movies = new List<DataItemVM>();

                InvokeOnMainThread(() => 
                {
                    foreach(var item in param)
                    {
                        StringBuilder desc = new StringBuilder();

                        desc.AppendLine("Название:").AppendLine(item.title);
                        desc.AppendLine("Средняя оценка:").AppendLine(item.vote_average);
                        desc.AppendLine("Количество голосов:").AppendLine(item.vote_count.ToString());
                        desc.AppendLine("Популярность:").AppendLine(item.popularity);
                        desc.AppendLine("Язык оригинала:").AppendLine(item.original_language);
                        desc.AppendLine("Оригинальное название:").AppendLine(item.original_title);
                        desc.AppendLine("Описание:").AppendLine(item.overview);
                        desc.AppendLine("Дата релиза:").AppendLine(DateTime.Parse(item.release_date).ToString());

                        Movies.Add(new DataItemVM(
                            item.id,
                            item.title,
                            "https://image.tmdb.org/t/p/w200" + item.poster_path,
                            desc
                        ));
                    }
                });
            }
            catch(Exception ex)
            {
                MvxTrace.Error(() => ex.StackTrace);
            }
            finally
            {
                Loading = true;
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
